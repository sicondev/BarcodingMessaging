using Sicon.API.Sage200.WebAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sicon.Sage200.Barcoding.MessageListener
{
    public class MessageServiceHandler : IMessageServiceRegistration
    {
        public void SubscribeToEvents()
        {
            Sage.Common.Messaging.MessageService ms = Sage.Common.Messaging.MessageService.GetInstance();

            ms.Subscribe(Sicon.API.Sage200.Objects.Messaging.Barcoding.BarcodingMessageSources.DespatchNotification, new Sage.Common.Messaging.MessageHandler(DespatchNotificationDetail));

        }

        public static Sage.Common.Messaging.Response DespatchNotificationDetail(object sender, Sage.Common.Messaging.MessageArgs args)
        {
            try
            {
                API.Sage200.Objects.Messaging.Barcoding.DespatchNotificationDetail oDespatchNotificationDetail = (API.Sage200.Objects.Messaging.Barcoding.DespatchNotificationDetail)sender;

                API.Sage200.Objects.Messaging.Barcoding.DespatchNotificationType oDespatchNotificationType = oDespatchNotificationDetail.DespatchNotificationType;
                long ForeignID = oDespatchNotificationDetail.ForeignID;
                decimal Quantity = oDespatchNotificationDetail.Quantity;
                long StockItemID = oDespatchNotificationDetail.StockItemID;
                List<API.Sage200.Objects.Models.TraceableBinItemQuantity> TraceableItems = oDespatchNotificationDetail.TraceableItems;
                API.Sage200.Objects.Messaging.Barcoding.TransactionType oTransactionType = oDespatchNotificationDetail.TransactionType;

                return new Sage.Common.Messaging.Response(Sage.Common.Messaging.ResponseArgs.Empty);
            }
            catch
            {
                throw;
            }
        }
    }
}
