using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    static class GetModelExtension
    {
        public static TResultModel getModel<TDbModel, TResultModel>(this TDbModel dbModel) where TResultModel : new()
        {
            var before = GC.GetTotalMemory(false);

            var dbModelProperties = dbModel.GetType().GetProperties();

            var resultModel = new TResultModel();
            var resultModelProperties = resultModel.GetType().GetProperties();

            foreach (var prop in resultModelProperties)
            {
                prop.SetValue(resultModel, dbModel.GetType().GetProperty(prop.Name).GetValue(dbModel));
            }

            //// yuxaridakinda her defe gettype deyib ordan getProperty ile propertini gotururem, 
            //// yeni reflection her defe isleyir (ya da men ele fikirlesirem)
            //// ona gore de daha cox memory consume eleyeceyini fikirlesirdim
            //// amma eksini gordum, yeni asagidaki ondan cox memory isledir
            //// "dbModelProperties" ozum qesden yuxarida yazdim ve gordum ki 
            //// ferq mehz ona goredi, yeni foreach-lerin icindekiler ferqe tesir elemir
            //// ona gore de oxunaqli olsun deye yuxaridaki "foreach" saxladim


            //foreach (var prop in resultModelProperties)
            //{
            //    foreach (var item in dbModelProperties)
            //    {
            //        if (item.Name.Equals(prop.Name))
            //        {
            //            prop.SetValue(resultModel, item.GetValue(dbModel));
            //        }
            //    }
            //}
            var after = GC.GetTotalMemory(false);
            Console.WriteLine("before -> " + before);
            Console.WriteLine("after -> " + after);
            Console.WriteLine("difference without GC and finalizer is " + (after - before));

            return resultModel;
        }
    }

}
