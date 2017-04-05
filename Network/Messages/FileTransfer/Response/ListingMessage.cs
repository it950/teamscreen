﻿using System;
using Network.Utils;
using Model;
using LiteNetLib.Utils;
using System.Collections.Generic;

namespace Network.Messages.FileTransfer.Response
{
	public class ListingMessage : BaseMessage
	{

        public List<Model.Listing> Entrys = new List<Model.Listing>();

		public ListingMessage()
			: base((ushort)CustomMessageType.ResponseListing)
		{
		}

		public override void WritePayload(NetDataWriter message)
		{
			base.WritePayload(message);
            message.Put(Entrys.Count);
            foreach (var entry in Entrys)
            {
                entry.WritePayload(message);
            }
        }

		public override void ReadPayload(NetDataReader message)
		{
			base.ReadPayload(message);
            int count = message.GetInt();

            for (int i = 0; i < count; i++)
            {
                Model.Listing entry = new Model.Listing();
                entry.ReadPayload(message);
                this.Entrys.Add(entry);
            }
        }

        public void addEntry(Model.Listing entry)
        {
            this.Entrys.Add(entry);
        }

	}
}
