public partial class Form1 : Form
{
    private BindingList<Product> products =
        new BindingList<Product>();

    private BindingSource productSource =
        new BindingSource();

    private string selectedImagePath = "";

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        LoadLoaiSP();
        LoadSampleData();
        SetupGrid();
        UpdateStatus("Sẵn sàng");
    }
}
