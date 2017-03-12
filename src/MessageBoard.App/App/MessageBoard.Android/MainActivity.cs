using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System;

namespace MessageBoard.Android
{
    [Activity(Label = "Message Board", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var btnSimple = (Button)FindViewById(Resource.Id.avancar);

            btnSimple.Click += delegate {
                var intent = obterValorBotao();
                StartActivity(intent);
            };
        }

        private Intent obterValorBotao()
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(ListagemRecados));
            var nomeInicial = FindViewById<EditText>(Resource.Id.nomeTelaInicial);
            intent.PutExtra("NomeUsuario", nomeInicial.Text);
            return intent;
        }
    }
}

