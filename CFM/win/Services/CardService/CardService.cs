using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace win.CardService
{
    public class CardService
    {
        #region 单例

        private static object lockobj = new object();
       
        private static CardService instance;
        public static CardService Instance
        {
            get 
            {
                if (instance == null)
                {
                    lock (lockobj)
                    {
                        if (instance == null)
                        {
                            instance = new CardService();
                        }
                    }
                }
                return instance;
            }
        }
        private CardService()
        {

        }

        #endregion
    }
}
