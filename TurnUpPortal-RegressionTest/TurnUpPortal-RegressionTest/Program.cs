using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortal_RegressionTest.Pages;

public class Program
{
    public static void Main(string[] args)
    {

        IWebDriver driver = new ChromeDriver();
        
        LoginPage lp = new LoginPage();
        lp.LoginActions(driver);


        HomePage hp = new HomePage();
        hp.UserLoginConfirm(driver);
        hp.Navigate(driver);

        TMPage tmp = new TMPage();
        tmp.createTimeRecord(driver);
        tmp.EditTimeRecord(driver);
        tmp.DeleteTimeRecord(driver);
        



        

        //  driver.Close();
    }
}