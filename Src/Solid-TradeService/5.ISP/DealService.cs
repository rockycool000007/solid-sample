﻿using System;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using TradeApp.Models;

namespace TradeApp
{
    public class DealService
    {
        public DealService(string username)
        {
            if (username == null)
            { throw new ArgumentNullException(nameof(username)); }

            if (!Directory.Exists(username))
            { Directory.CreateDirectory(username); }

            Username = username;
            Cache = new DealCaching();
            Storage = new FileDealStorage(username);
            Serializer = new DealSerializer();
            Logger = new DealServiceLogger();
        }

        public virtual IDealCaching Cache { get; }

        public virtual IDealStorage Storage { get; }

        public virtual IDealServiceLogger Logger { get; }

        public virtual IDealSerializer Serializer { get; }
        
        public string Username { get; }
        
        public void Save(string id, Deal deal)
        {
            Logger.Saving(deal);
            Storage.Save(id, Serializer.SerializeDeal(deal));
            Cache.Save(id, new Maybe<Deal>(deal));
            Logger.Saved(deal);
        }

        public Maybe<Deal> Load(string id)
        {
            Logger.Loading(id);

            var deal = Cache.Load(id, _ =>
                {
                    var serializedDeal = Storage.Load(id);
                    return Serializer.DeserializeDeal(serializedDeal);
                });

            if (deal.Any())
                Logger.Loaded(deal.First());
            else
                Logger.DidNotFind(id);
            
            return deal;
        }
    }
}
