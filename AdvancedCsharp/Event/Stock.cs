namespace AdvancedCsharp.Event;

public interface IFoo
{
    event EventHandler Ev;
}

class Foo : IFoo 
{ 
    private EventHandler ev; 
    event EventHandler IFoo.Ev 
    { 
        add    
        { ev += value; } 
        remove { ev -= value; } 
    } 
}

/*Like methods, e ents can be irtual, o erridden, abstract, or sealed. Eents
    can also be static:*/
public class Teste 
{ 
    public static event EventHandler<EventArgs> StaticEvent; 
    public virtual event EventHandler<EventArgs> VirtualEvent; 
}


public class PriceChangedEventArgs : System.EventArgs
{
    public readonly decimal LastPrice;
    public readonly decimal NewPrice;

    public PriceChangedEventArgs(decimal lastPrice, decimal newPrice)
    {
        LastPrice = lastPrice;
        NewPrice = newPrice;
    }
}

public class Stock
{
    private string _symbol;
    private decimal _price;

    public Stock(string symbol) => this._symbol = symbol;

    public event EventHandler<PriceChangedEventArgs> PriceChanged;

    protected virtual void OnPriceChanged(PriceChangedEventArgs e)
    {
       PriceChanged?.Invoke(this, e);
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (_price == value)
            {
                return;
            }
            
            decimal oldPrice = _price;
            _price = value;
            OnPriceChanged(new PriceChangedEventArgs(oldPrice, _price));
        }
    }
}

public delegate void EventHandler<TEventArgs>(object source, TEventArgs e);