namespace LabaDLG5Task;

using System;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private delegate void ActionDelegate();
    private event ActionDelegate? SuperMegaAction;

    private bool isTransparent = false;
    private Color[] colors = { Color.Gray, Color.Yellow, Color.White };
    private int colorIndex = 0;

    Button btnTransparency = new Button();
    Button btnBackgroundColor = new Button();
    Button btnHelloWorld = new Button();
    Button btnSuperMega = new Button();
    CheckBox chkTransparency = new CheckBox();
    CheckBox chkBackgroundColor = new CheckBox();
    CheckBox chkHelloWorld = new CheckBox();

    public Form1()
    {
        InitializeComponent();
        SetupUI();

        btnTransparency.Click += (s, e) => ToggleTransparency();
        btnBackgroundColor.Click += (s, e) => ChangeBackgroundColor();
        btnHelloWorld.Click += (s, e) => ShowHelloWorld();

        SuperMegaAction += () =>
        {
            if (chkTransparency.Checked) ToggleTransparency();
            if (chkBackgroundColor.Checked) ChangeBackgroundColor();
            if (chkHelloWorld.Checked) ShowHelloWorld();
        };
    }

    private void SetupUI()
    {
        this.Text = "SuperMegaButtonApp";
        this.Size = new Size(400, 300);

        btnTransparency.Text = "Прозорість";
        btnBackgroundColor.Text = "Колір тла";
        btnHelloWorld.Text = "hello world";
        btnSuperMega.Text = "супермегакнопка";
        chkTransparency.Text = "Прозорість";
        chkBackgroundColor.Text = "Колір тла";
        chkHelloWorld.Text = "hello world";

        btnTransparency.Location = new Point(10, 10);
        btnBackgroundColor.Location = new Point(10, 50);
        btnHelloWorld.Location = new Point(10, 90);
        btnSuperMega.Location = new Point(10, 130);
        chkTransparency.Location = new Point(150, 10);
        chkBackgroundColor.Location = new Point(150, 50);
        chkHelloWorld.Location = new Point(150, 90);

        btnSuperMega.Click += btnSuperMega_Click;

        this.Controls.Add(btnTransparency);
        this.Controls.Add(btnBackgroundColor);
        this.Controls.Add(btnHelloWorld);
        this.Controls.Add(btnSuperMega);
        this.Controls.Add(chkTransparency);
        this.Controls.Add(chkBackgroundColor);
        this.Controls.Add(chkHelloWorld);
    }

    private void ToggleTransparency()
    {
        isTransparent = !isTransparent;
        this.Opacity = isTransparent ? 0.5 : 1.0;
    }

    private void ChangeBackgroundColor()
    {
        colorIndex = (colorIndex + 1) % colors.Length;
        this.BackColor = colors[colorIndex];
    }

    private void ShowHelloWorld()
    {
        MessageBox.Show("Hello, world!");
    }

    private void btnSuperMega_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Я супермегакнопка, \ni цього мене не позбавиш!");

        SuperMegaAction?.Invoke();
    }
}
