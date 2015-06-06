using MongoDB.Bson.Serialization.Attributes;

namespace PizzaConsole
{

    public abstract class BaseT
    {
        public int Id { get; set; }
        public virtual decimal Cost { get; set; }

        public virtual bool ShouldSerializeCost()
        {
            return true;
        }
    }


    public class Test2 : BaseT
    {
        public string Name { get; set; }
    }

    public class Test : BaseT
    {
        
        public string Name { get; set; }
        [BsonIgnore]
        public override decimal Cost { get; set; }

        public override bool ShouldSerializeCost()
        {
            return false;
        }
    }

}
