using gmFucker.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmFucker.DataAccess.Adapters
{
    /// <summary>
    /// 範例資料傳輸類別
    /// </summary>
    public class TempAdapter : DataAdapterBase
    {
        /// <summary>
        /// 依訂單標號取得第三方支付交易記錄資料集合
        /// </summary>
        /// <param name="formID">訂單編號</param>
        /// <returns>第三方支付交易記錄資料集合</returns>
        public IEnumerable<OrderWithThirdPartyPayEntity> getThirdPartyOrderCollection(string formID)
        {
            Dictionary<string, object> parameterDic = new Dictionary<string, object>()
            {
                {"FormID",formID}
            };
            return base.executeStoredProcedure_WithReturnValue<OrderWithThirdPartyPayEntity>(StoreProcedures.OrderWithThirdPartyPay.OrderWithThirdPartyPay_GetByFormID, this.getOrderWithThirdPartyPayEntityData, parameterDic);
        }

        /// <summary>
        /// 依第三方支付類型取得第三方支付交易記錄資料集合
        /// </summary>
        /// <param name="thirdPartyPayType">第三方支付類型</param>
        /// <returns>第三方支付交易記錄資料集合</returns>
        public IEnumerable<OrderWithThirdPartyPayEntity> getThirdPartyOrderCollection(byte thirdPartyPayType)
        {
            Dictionary<string, object> parameterDic = new Dictionary<string, object>()
            {
                {"ThirdPartyPayType",thirdPartyPayType}
            };
            return base.executeStoredProcedure_WithReturnValue<OrderWithThirdPartyPayEntity>(StoreProcedures.OrderWithThirdPartyPay.OrderWithThirdPartyPay_GetByThirdPartyPayType, this.getOrderWithThirdPartyPayEntityData, parameterDic);
        }
                

        /// <summary>
        /// 新增一筆第三方支付交易記錄資料
        /// </summary>
        /// <param name="orderWithThirdPartyPayEntity">第三方支付交易記錄資料</param>
        public void addThirdPartyOrder(OrderWithThirdPartyPayEntity orderWithThirdPartyPayEntity)
        {
            if (base.executeStoredProcedure(StoreProcedures.OrderWithThirdPartyPay.OrderWithThirdPartyPay_Add,
                new SqlParameter("FormID", SqlDbType.NVarChar) { Size = 20, Value = orderWithThirdPartyPayEntity.FormID },
                new SqlParameter("FormType", SqlDbType.TinyInt) { Value = orderWithThirdPartyPayEntity.FormType },
                new SqlParameter("ThirdPartyPayOrderNumber", SqlDbType.VarChar) { Size = 50, Value = String.IsNullOrEmpty(orderWithThirdPartyPayEntity.ThirdPartyPayOrderNumber) ? (Object)DBNull.Value : orderWithThirdPartyPayEntity.ThirdPartyPayOrderNumber },
                new SqlParameter("ThirdPartyPayQRCode", SqlDbType.VarBinary) { Value = orderWithThirdPartyPayEntity.ThirdPartyPayQRCode == null ? (Object)DBNull.Value : orderWithThirdPartyPayEntity.ThirdPartyPayQRCode },
                new SqlParameter("ThirdPartyPayType", SqlDbType.TinyInt) { Value = orderWithThirdPartyPayEntity.ThirdPartyPayType },
                new SqlParameter("Status", SqlDbType.TinyInt) { Value = orderWithThirdPartyPayEntity.Status },
                new SqlParameter("TransAmount", SqlDbType.Int) { Value = orderWithThirdPartyPayEntity.TransAmount },
                new SqlParameter("PaymentDeadLine", SqlDbType.DateTime) { Value = orderWithThirdPartyPayEntity.PaymentDeadLine.HasValue ? orderWithThirdPartyPayEntity.PaymentDeadLine.Value : (Object)DBNull.Value },
                new SqlParameter("PaymentCompletedDate", SqlDbType.DateTime) { Value = orderWithThirdPartyPayEntity.PaymentCompletedDate.HasValue ? orderWithThirdPartyPayEntity.PaymentCompletedDate.Value : (Object)DBNull.Value },
                new SqlParameter("PaymentFailedDate", SqlDbType.DateTime) { Value = orderWithThirdPartyPayEntity.PaymentFailedDate.HasValue ? orderWithThirdPartyPayEntity.PaymentFailedDate.Value : (Object)DBNull.Value },
                new SqlParameter("RefundDate", SqlDbType.DateTime) { Value = orderWithThirdPartyPayEntity.RefundDate.HasValue ? orderWithThirdPartyPayEntity.RefundDate.Value : (Object)DBNull.Value },
                new SqlParameter("CreatedDate", SqlDbType.DateTime) { Value = orderWithThirdPartyPayEntity.CreatedDate },
                new SqlParameter("UpdatedDate", SqlDbType.DateTime) { Value = orderWithThirdPartyPayEntity.UpdatedDate.HasValue ? orderWithThirdPartyPayEntity.UpdatedDate.Value : (Object)DBNull.Value },
                new SqlParameter("ThirdPartyPayCode", SqlDbType.VarChar) { Size = 36, Value = String.IsNullOrEmpty(orderWithThirdPartyPayEntity.ThirdPartyPayCode) ? (Object)DBNull.Value : orderWithThirdPartyPayEntity.ThirdPartyPayCode },
                new SqlParameter("ThirdPartyPayMessage", SqlDbType.NVarChar) { Size = 1000, Value = String.IsNullOrEmpty(orderWithThirdPartyPayEntity.ThirdPartyPayMessage) ? (Object)DBNull.Value : orderWithThirdPartyPayEntity.ThirdPartyPayMessage })
                != 1)
            {
                throw new InvalidOperationException("新增第三方交易紀錄預期應影響一筆資料");
            }
        }        

        private OrderWithThirdPartyPayEntity getOrderWithThirdPartyPayEntityData(SqlDataReader reader)
        {
            return new OrderWithThirdPartyPayEntity()
            {
                ID = (long)reader["ID"],
                FormID = (string)reader["FormID"],
                FormType = (byte)reader["FormType"],
                ThirdPartyPayOrderNumber = reader["ThirdPartyPayOrderNumber"] == DBNull.Value ? null : (string)reader["ThirdPartyPayOrderNumber"],
                ThirdPartyPayQRCode = reader["ThirdPartyPayQRCode"] == DBNull.Value ? null : (byte[])reader["ThirdPartyPayQRCode"],
                ThirdPartyPayType = (byte)reader["ThirdPartyPayType"],
                Status = (byte)reader["Status"],
                TransAmount = (int)reader["TransAmount"],
                PaymentDeadLine = reader["PaymentDeadLine"] == DBNull.Value ? null : (DateTime?)reader["PaymentDeadLine"],
                PaymentCompletedDate = reader["PaymentCompletedDate"] == DBNull.Value ? null : (DateTime?)reader["PaymentCompletedDate"],
                PaymentFailedDate = reader["PaymentFailedDate"] == DBNull.Value ? null : (DateTime?)reader["PaymentFailedDate"],
                RefundDate = reader["RefundDate"] == DBNull.Value ? null : (DateTime?)reader["RefundDate"],
                CreatedDate = (DateTime)reader["CreatedDate"],
                UpdatedDate = reader["UpdatedDate"] == DBNull.Value ? null : (DateTime?)reader["UpdatedDate"],
                ThirdPartyPayCode = reader["ThirdPartyPayCode"] == DBNull.Value ? null : (string)reader["ThirdPartyPayCode"],
                ThirdPartyPayMessage = reader["ThirdPartyPayMessage"] == DBNull.Value ? null : (string)reader["ThirdPartyPayMessage"]
            };
        }
    }
}
