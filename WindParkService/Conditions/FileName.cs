//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WindParkService.DataModel;

//namespace WindParkService.Conditions
//{
//    public interface ITurbineCondition
//    {
//        bool Evaluate(Turbine turbine, float productionNeeded, float currentMarketPrice);
//    }

//    public interface ITurbineAction
//    {
//        void Execute(Turbine turbine);
//    }

//    public class PriceCondition : ITurbineCondition
//    {
//        public bool Evaluate(Turbine turbine, float productionNeeded, float currentMarketPrice)
//        {
//            return currentMarketPrice > turbine.ProductionCost;
//        }
//    }

//    public class CapacityCondition : ITurbineCondition
//    {
//        public bool Evaluate(Turbine turbine, float productionNeeded, float currentMarketPrice)
//        {
//            return productionNeeded >= turbine.MaxCapacity;
//        }
//    }

//    public class StartAction : ITurbineAction
//    {
//        public void Execute(Turbine turbine)
//        {
//            turbine.Start();
//        }
//    }

//    public class StopAction : ITurbineAction
//    {
//        public void Execute(Turbine turbine)
//        {
//            turbine.Stop();
//        }
//    }
//}
