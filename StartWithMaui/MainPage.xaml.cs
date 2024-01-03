using MauiApp2;
namespace StartWithMaui;

public partial class MainPage : ContentPage
{
	List<string> imagesUrl = new List<string>();
	int current = 0;
    List<Monkey> monkeys = new List<Monkey>();
	
    public MainPage()
	{
		monkeys = Monkey.GetMonkeys();
		InitializeComponent();
		for (int i = 0; i < monkeys.ToArray().Length; i++)
			imagesUrl.Add(monkeys[i].Image);
	}

	private void ButtonEnabled()
	{
        if (current <= 0)
            down_btn.IsEnabled = false;
        else if (current >= imagesUrl.Count - 1)
        {
            up_btn.IsEnabled = false;
        }
        else
        {
            up_btn.IsEnabled = true;
            down_btn.IsEnabled = true;

        }
    }
	private void ChangePhoto(object sender, EventArgs e)
	{
		Button btn = sender as Button;//נמיר את האובייקט לכפתור שהפעיל את האירוע
			

			//נבדוק מי הכפתור שהפעיל את האירוע
			if (btn == up_btn)//האם זה הכפתור למעלה?
				current = current + 1;
        slide_img.Source= imagesUrl[current];
		label.Text = $"{current + 1}/ {monkeys.ToArray().Length}";
            if (btn == down_btn)
				current = current - 1;

			slide_img.Source = imagesUrl[current];

		ButtonEnabled();
		



    }
	


    
}

