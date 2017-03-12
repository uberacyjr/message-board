using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MessageBoard.Android.Utils;
using MessageBoard.Android.Models;

namespace MessageBoard.Android
{
    [Activity(Label = "Listagem")]
    public class ListagemRecados : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ListaRecados);
            var nomeUsuarioVisualizando = Intent.Extras.GetString("NomeUsuario", "Nome");
            Title = nomeUsuarioVisualizando;
            var pessoas = new List<Recado>() { new Recado { Nome = "Uberacy" } };
            ListView itens = FindViewById<ListView>(Resource.Id.listViewReacados);
            itens.Adapter = new CustomListRecados(this, pessoas);
            itens.FastScrollEnabled = true;

            var btnNovo = FindViewById<Button>(Resource.Id.novaMensagem);

            btnNovo.Click += delegate
            {
                var intent = new Intent();
                intent.SetClass(this, typeof(NovaMensagem));
                StartActivity(intent);
            };
        }
    }
}