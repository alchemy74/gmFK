using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmFucker.DataAccess.Base
{

    /// <summary>
    /// 資料庫預存程序(範例)
    /// </summary>
    internal class StoreProcedures
    {
        /// <summary>
        /// 第三方支付的預存程序
        /// </summary>
        internal struct OrderWithThirdPartyPay
        {
            /// <summary>
            /// 新增一筆第三方支付交易記錄資料的資料庫預存程序
            /// </summary>
            internal const string OrderWithThirdPartyPay_Add = "usp_OrderWithThirdPartyPay_Add";

            /// <summary>
            /// 依流水號ID取得第三方支付交易記錄的資料庫預存程序
            /// </summary>
            internal const string OrderWithThirdPartyPay_Get = "usp_OrderWithThirdPartyPay_Get";

            /// <summary>
            /// 依訂單標號取得第三方支付交易記錄資料集合的資料庫預存程序
            /// </summary>
            internal const string OrderWithThirdPartyPay_GetByFormID = "usp_OrderWithThirdPartyPay_GetByFormID";

            /// <summary>
            /// 依第三方支付訂單編號取得第三方支付交易記錄資料集合的資料庫預存程序
            /// </summary>
            internal const string OrderWithThirdPartyPay_GetByThirdPartyPayOrderNumber = "usp_OrderWithThirdPartyPay_GetByThirdPartyPayOrderNumber";

            /// <summary>
            /// 依付款狀態取得第三方支付交易記錄資料集合的資料庫預存程序
            /// </summary>
            internal const string OrderWithThirdPartyPay_GetByStatus = "usp_OrderWithThirdPartyPay_GetByStatus";

            /// <summary>
            /// 依第三方支付類型取得第三方支付交易記錄資料集合的資料庫預存程序
            /// </summary>
            internal const string OrderWithThirdPartyPay_GetByThirdPartyPayType = "usp_OrderWithThirdPartyPay_GetByThirdPartyPayType";

            /// <summary>
            /// 修改一筆第三方交易紀錄資料的資料庫預存程序
            /// </summary>
            internal const string OrderWithThirdPartyPay_Update = "usp_OrderWithThirdPartyPay_Update";
        }

        internal struct SiteSettings
        {
            /// <summary>
            /// 新增一筆頁面設定項目的資料庫預存程序
            /// </summary>
            internal const string SiteSettings_Add = "usp_SiteSettings_Add";

            /// <summary>
            /// 刪除一筆頁面設定項目的資料庫預存程序
            /// </summary>
            internal const string SiteSettings_Delete = "usp_SiteSettings_Delete";

            /// <summary>
            /// 依ID取得一筆頁面設定項目的資料庫預存程序
            /// </summary>
            internal const string SiteSettings_Get = "usp_SiteSettings_Get";

            /// <summary>
            /// 依ID修改一筆頁面設定項目的資料庫預存程序
            /// </summary>
            internal const string SiteSettings_Update = "usp_SiteSettings_Update";
        }
    }
}
