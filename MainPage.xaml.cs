using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using Windows.Web.Http;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Empower
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            ApplicationData appData = ApplicationData.Current;

            if(appData.LocalSettings.Values["FirstName"] != null) FirstName.Text = appData.LocalSettings.Values["FirstName"] as string;
            if (appData.LocalSettings.Values["LastName"] != null) LastName.Text = appData.LocalSettings.Values["LastName"] as string;
            if (appData.LocalSettings.Values["Email"] != null) Email.Text = appData.LocalSettings.Values["Email"] as string;
            if (appData.LocalSettings.Values["AddressStreet1"] != null) AddressStreet1.Text = appData.LocalSettings.Values["AddressStreet1"] as string;
            if (appData.LocalSettings.Values["AddressStreet2"] != null) AddressStreet2.Text = appData.LocalSettings.Values["AddressStreet2"] as string;
            if (appData.LocalSettings.Values["AddressCity"] != null) AddressCity.Text = appData.LocalSettings.Values["AddressCity"] as string;
            if (appData.LocalSettings.Values["AddressState"] != null) AddressState.Text = appData.LocalSettings.Values["AddressState"] as string;
            if (appData.LocalSettings.Values["AddressZipCode"] != null) AddressZipCode.Text = appData.LocalSettings.Values["AddressZipCode"] as string;
            if (appData.LocalSettings.Values["CCNumber"] != null) CCNumber.Text = appData.LocalSettings.Values["CCNumber"] as string;
            if (appData.LocalSettings.Values["CCExpMonth"] != null) CCExpMonth.Text = appData.LocalSettings.Values["CCExpMonth"] as string;
            if (appData.LocalSettings.Values["CCExpYear"] != null) CCExpYear.Text = appData.LocalSettings.Values["CCExpYear"] as string;
            if (appData.LocalSettings.Values["CCCvv"] != null) CCCvv.Text = appData.LocalSettings.Values["CCCvv"] as string;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationData appData = ApplicationData.Current;

            appData.LocalSettings.Values["FirstName"] = FirstName.Text;
            appData.LocalSettings.Values["LastName"] = LastName.Text;
            appData.LocalSettings.Values["Email"] = Email.Text;
            appData.LocalSettings.Values["AddressStreet1"] = AddressStreet1.Text;
            appData.LocalSettings.Values["AddressStreet2"] = AddressStreet2.Text;
            appData.LocalSettings.Values["AddressCity"] = AddressCity.Text;
            appData.LocalSettings.Values["AddressState"] = AddressState.Text;
            appData.LocalSettings.Values["AddressZipCode"] = AddressZipCode.Text;
            appData.LocalSettings.Values["CCNumber"] = CCNumber.Text;
            appData.LocalSettings.Values["CCExpMonth"] = CCExpMonth.Text;
            appData.LocalSettings.Values["CCExpYear"] = CCExpYear.Text;
            appData.LocalSettings.Values["CCCvv"] = CCCvv.Text;
        }

        private async void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            ApplicationData appData = ApplicationData.Current;

            // Create the corresponding message
            HttpMultipartFormDataContent content = new HttpMultipartFormDataContent();

            content.Add(new HttpStringContent("0"), "submitted[donation][aclu_recurring]");
            content.Add(new HttpStringContent("other"), "submitted[donation][amount]");
            content.Add(new HttpStringContent("5"), "submitted[donation][other_amount]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["FirstName"] as string), "submitted[donor_information][first_name]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["LastName"] as string), "submitted[donor_information][last_name]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["Email"] as string), "submitted[donor_information][email]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["AddressStreet1"] as string), "submitted[billing_information][address]");
            if (appData.LocalSettings.Values["AddressStreet2"] != null) content.Add(new HttpStringContent(appData.LocalSettings.Values["AddressStreet2"] as string), "submitted[billing_information][address_line_2]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["AddressCity"] as string), "submitted[billing_information][city]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["AddressState"] as string), "submitted[billing_information][state]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["AddressZipCode"] as string), "submitted[billing_information][zip]");
            content.Add(new HttpStringContent("840"), "submitted[billing_information][country]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["CCNumber"] as string), "submitted[credit_card_information][card_number]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["CCExpMonth"] as string), "submitted[credit_card_information][expiration_date][card_expiration_month]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["CCExpYear"] as string), "submitted[credit_card_information][expiration_date][card_expiration_year]");
            content.Add(new HttpStringContent(appData.LocalSettings.Values["CCCvv"] as string), "submitted[credit_card_information][card_cvv]");
            content.Add(new HttpStringContent("0"), "submitted[credit_card_information][fight_for_freedom][1]");
            content.Add(new HttpStringContent("0"), "submitted[credit_card_information][profile_may_we_share_your_info][1]");

            // Hidden fields
            content.Add(new HttpStringContent("70114000002VStAAAW"), "submitted[cid]");
            content.Add(new HttpStringContent("web_4square_gol"), "submitted[ms]");
            content.Add(new HttpStringContent(""), "submitted[referrer]");
            content.Add(new HttpStringContent("NAT"), "submitted[Form_Affiliation]");
            content.Add(new HttpStringContent(""), "submitted[initial_referrer]");
            content.Add(new HttpStringContent(""), "submitted[o_src]");
            content.Add(new HttpStringContent("http://www.aclu.org/node/58519"), "submitted[ms_path]");
            content.Add(new HttpStringContent("UNV170001C00"), "submitted[s_src]");
            content.Add(new HttpStringContent("Fight Back Against Attacks on Our Civil Liberties"), "submitted[ms_title]");
            content.Add(new HttpStringContent(""), "details[sid]");
            content.Add(new HttpStringContent("1"), "details[page_num]");
            content.Add(new HttpStringContent("1"), "details[page_count]");
            content.Add(new HttpStringContent("0"), "details[finished]");
            content.Add(new HttpStringContent("form-YpX4CexH5zO2_XFzJE1-cWonVmR50IF4FdSU9cN3Lzg"), "form_build_id");
            content.Add(new HttpStringContent("webform_client_form_58241"), "form_id");
            content.Add(new HttpStringContent(""), "aclu-name");
            content.Add(new HttpStringContent("DONATE MONTHLY"), "op");

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, new Uri("https://action.aclu.org/node/58241"));

            message.Headers["User-agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.79 Safari/537.36 Edge/14.14393";
            message.Headers["Accept-Charset"] = "UTF-8";

            message.Content = content;

            // Send it
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.SendRequestAsync(message);
            string responseText = await response.Content.ReadAsStringAsync();
            StatusCode.Text = response.StatusCode.ToString();
            Request.Text = await response.RequestMessage.Content.ReadAsStringAsync();
            Response.NavigateToString(responseText);
        }
    }
}
