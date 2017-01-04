using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmFucker.DataAccess.Models
{
    /// <summary>
    /// 記錄與第三方支付介接之訂單狀態及關聯的資料實體
    /// </summary>
    public class OrderWithThirdPartyPayEntity
    {
        /// <summary>
        /// 流水號
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// 訂單編號
        /// </summary>
        public string FormID { get; set; }

        /// <summary>
        /// 訂單類型
        /// </summary>
        public byte FormType { get; set; }

        /// <summary>
        /// 第三方支付訂單編號
        /// </summary>
        public string ThirdPartyPayOrderNumber { get; set; }

        /// <summary>
        /// 掃描用QRCode資料
        /// </summary>
        public byte[] ThirdPartyPayQRCode { get; set; }

        /// <summary>
        /// 第三方支付類型
        /// </summary>
        public byte ThirdPartyPayType { get; set; }

        /// <summary>
        /// 付款狀態
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 交易金額
        /// </summary>
        public int TransAmount { get; set; }

        /// <summary>
        /// 最後付款期限時間
        /// </summary>
        public DateTime? PaymentDeadLine { get; set; }

        /// <summary>
        /// 付款完成時間
        /// </summary>
        public DateTime? PaymentCompletedDate { get; set; }

        /// <summary>
        /// 付款失敗時間
        /// </summary>
        public DateTime? PaymentFailedDate { get; set; }

        /// <summary>
        /// 退款時間
        /// </summary>
        public DateTime? RefundDate { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// 修改時間
        /// </summary>
        public DateTime? UpdatedDate { get; set; }

        /// <summary>
        /// 第三方回傳代碼
        /// </summary>
        public string ThirdPartyPayCode { get; set; }

        /// <summary>
        /// 第三方回傳內容
        /// </summary>
        public string ThirdPartyPayMessage { get; set; }
    }
}
