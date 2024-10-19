using Gdk;
using Gtk;
using System.IO;
using System.IO.Ports;

class MyWindow : Gtk.Window {
    public MyWindow() : base("DN-500BD Remote") {
    }

    protected override bool OnDeleteEvent(Event e) {
        Application.Quit();
        return true;
    }
}

class Hello {
    private static SerialPort mySerial;

    public string ReadData()
    {
        byte tmpByte;
        string rxString = "";
 
        tmpByte = (byte) mySerial.ReadByte();
 
        while (tmpByte != 255) {
            rxString += ((char) tmpByte);
            tmpByte = (byte) mySerial.ReadByte();
        }
 
        return rxString;
    }
 
    public bool SendData(string Data)
    {  
        mySerial.Write(Data);
        return true;
    }
    static void on_upclick(object? sender, EventArgs args) {
        Console.WriteLine("up");
        return;
    }

        static void on_dnclick(object? sender, EventArgs args) {
        Console.WriteLine("down");
        return;
    }
        static void on_lfclick(object? sender, EventArgs args) {
        Console.WriteLine("left");
        return;
    }
        static void on_rtclick(object? sender, EventArgs args) {
        Console.WriteLine("right");
        return;
    }

        static void on_entclick(object? sender, EventArgs args) {
        Console.WriteLine("enter");
        return;
    }

    static void Main() {

        //mySerial = new SerialPort("/dev/ttyS0", 9600);
        //mySerial.Open();
        //mySerial.ReadTimeout = 400;

        Application.Init();

        string[] ports = SerialPort.GetPortNames();
        Entry portBox = new Entry();
        ListStore store = new ListStore(typeof(string));
        
        store.AppendValues(ports);

        portBox.Completion = new EntryCompletion ();
        portBox.Completion.Model = store;
        portBox.Completion.TextColumn = 0;

        MyWindow w = new MyWindow();
        VBox v = new VBox();
        HBox h = new HBox();

        h.Add(portBox);
        v.Add(h);

        h = new HBox();

        h.Add(new Label());

        Button up = new Button();
        up.Label = "^";
        up.Clicked += on_upclick;

        h.Add(up);
        
        h.Add(new Label());
        v.Add(h);

        h = new HBox();

        Button lf = new Button();
        lf.Label = "<";
        lf.Clicked += on_lfclick;

        Button ent = new Button();
        ent.Label = "Enter";
        ent.Clicked += on_entclick;

        Button rt = new Button();
        rt.Label = ">";
        rt.Clicked += on_rtclick;

        h.Add(lf);
        h.Add(ent);
        h.Add(rt);
        v.Add(h);

        h = new HBox();
        h.Add(new Label());
        
        Button dn = new Button();
        dn.Label = "V";
        dn.Clicked += on_dnclick;

        h.Add(dn);
        h.Add(new Label());
       
        v.Add(h);
       
        w.Add(v);
        w.ShowAll();
        
        Application.Run();
    }
}
