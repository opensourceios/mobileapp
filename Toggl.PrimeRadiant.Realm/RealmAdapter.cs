﻿using System;
using System.Linq;
using Realms;
using Toggl.Multivac;
using Toggl.Multivac.Models;

namespace Toggl.PrimeRadiant.Realm
{
    internal interface IRealmAdapter<TModel>
        where TModel : IBaseModel, IDatabaseSyncable
    {
        IQueryable<TModel> GetAll();

        void Delete(TModel entity);

        TModel Create(TModel entity);

        TModel Update(TModel entity);   
    }

    internal sealed class RealmAdapter<TRealmEntity, TModel> : IRealmAdapter<TModel>
        where TRealmEntity : RealmObject, TModel
        where TModel: IBaseModel, IDatabaseSyncable
    {
        private readonly Func<TModel, TRealmEntity> convertToRealm;

        public RealmAdapter(Func<TModel, TRealmEntity> convertToRealm)
        {
            Ensure.ArgumentIsNotNull(convertToRealm, nameof(convertToRealm));

            this.convertToRealm = convertToRealm;
        }

        public IQueryable<TModel> GetAll()
            => Realms.Realm.GetInstance().All<TRealmEntity>();

        public TModel Create(TModel entity)
            => doTransaction(entity, (realm, model) => realm.Add(model), false);

        public TModel Update(TModel entity)
            => doTransaction(entity, (realm, model) => realm.Add(model, true), true);

        public void Delete(TModel entity)
            => doTransaction(entity, (realm, model) => realm.Remove(model), true);

        private void doTransaction(TModel entity, Action<Realms.Realm, TRealmEntity> transactionAction, bool checkExistance)
            => doTransaction(entity, (realm, model) => { transactionAction(realm, model); return null; }, checkExistance);

        private TRealmEntity doTransaction(
            TModel entity, Func<Realms.Realm, TRealmEntity, TRealmEntity> transactionAction, bool checkExistance)
        {
            Ensure.ArgumentIsNotNull(entity, nameof(entity));

            var realm = Realms.Realm.GetInstance();
            var realmEntity = convertToRealm(entity);

            using (var transaction = realm.BeginWrite())
            {
                if (checkExistance)
                {
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    realm.All<TRealmEntity>().Single(x => x.Id == entity.Id);
                }

                var returnValue = transactionAction(realm, realmEntity);
                transaction.Commit();

                return returnValue;
            }
        }

    }
}
