using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using Track.Core.Models;

namespace Track.Core.Repository
{
    /// <summary>
    /// A MongoDB repository. Maps to a collection with the same name
    /// as type TEntity.
    /// </summary>
    /// <typeparam name="T">Entity type for this repository</typeparam>
    public class MongoDbRepository<TEntity> :
        IRepository<TEntity> where
            TEntity : EntityBase
    {
        private MongoDatabase database;
        private MongoCollection<TEntity> collection;

        public MongoDbRepository()
        {
            GetDatabase();
            GetCollection();
        }

        public TEntity Insert(TEntity entity)
        {
            collection.Insert(entity);
            return entity;
        }

        public bool Update(TEntity entity)
        {
            if (entity.Id == null)
            {
                return false;
            }
            else
            {

                return collection
                    .Save(entity)
                        .DocumentsAffected > 0;
            }
        }

        public bool Delete(TEntity entity)
        {
            return collection
                .Remove(Query.EQ("_id", entity.Id))
                    .DocumentsAffected > 0;
        }
        public bool DeleteAll(TEntity entity)
        {
            return collection.RemoveAll().DocumentsAffected > 0;

        }
        public bool Drop(TEntity entity)
        {
            return collection.Drop().Ok;

        }


        public IList<TEntity>
            SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return collection
                .AsQueryable<TEntity>()
                    .Where(predicate.Compile())
                        .ToList();
        }

        public IList<TEntity> GetAll()
        {
            return collection.FindAllAs<TEntity>().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return collection.FindOneByIdAs<TEntity>(id);
        }

        #region Private Helper Methods
        private void GetDatabase()
        {
            //var client = new MongoClient(GetConnectionString());
            //var server = client.GetServer();
            //database =server.GetDatabase(GetDatabaseName());
            database = MongoDatabase.Create(GetConnectionString());
           
        }

        private string GetConnectionString()
        {


            //return ConfigurationManager
            //    .AppSettings
            //        .Get("MongoDbConnectionString");

            return ConfigurationManager.AppSettings.Get("MONGOHQ_URL") ??
                    ConfigurationManager.AppSettings.Get("MONGOLAB_URI") ??
                    "mongodb://localhost/Things";

        }
        /*
        private string GetDatabaseName()
        {

            return ConfigurationManager
                .AppSettings
                    .Get("MongoDbDatabaseName");
        }
        */
        private void GetCollection()
        {
            collection = database
                .GetCollection<TEntity>(typeof(TEntity).Name);
        }
        #endregion
    }
}