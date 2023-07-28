using MongoDB.Driver;
using MyBestDataClassEver.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _DbClass = MyBestDataClassEver.Entities.SavedResults;


namespace MyBestDataClassEver {
    public class CalcDataDal {
        public string CollectionName { get; set; } = typeof(_DbClass).Name;

        public IMongoCollection<_DbClass> _collection;

        public CalcDataDal(IMongoDatabase db) {
            _collection = db.GetCollection<_DbClass>(CollectionName);
        }

        public _DbClass? Get(string? id) {
            return _collection.Find(x => x.id == id).FirstOrDefault();
        }

        public IQueryable<_DbClass>? GetQueryable() {
            return _collection.AsQueryable();
        }

        public _DbClass? InsertNew(string prefix, _DbClass x) {
            var z = x;
            string identifier = IdHelper.RndId(null, CollectionName);
            var res = Get(identifier);
            while (res != null) {
                identifier = IdHelper.RndId(prefix, CollectionName);
                res = Get(identifier);
            }
            z.id = identifier;
            _collection.InsertOne(x);
            return x;
        }
    }
}
