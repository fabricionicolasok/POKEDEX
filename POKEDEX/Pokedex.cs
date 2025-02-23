using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;
using Model;

namespace POKEDEX
{
    public partial class Pokedex : Form
    {
        private List<Pokemon> listaPokemon;

        public Pokedex()
        {
            InitializeComponent();
        }

        private void Pokedex_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listaPokemon = negocio.listar();
            dgvPokemon.DataSource = listaPokemon;
            dgvPokemon.Columns[3].Visible = false;
            cargarImagen(listaPokemon[0].UrlImgen);
        }

        private void dgvPokemon_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemon.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImgen);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pboxPokemon.Load(imagen);
            }
            catch (Exception ex)
            {
                pboxPokemon.Load("https://media.istockphoto.com/id/1147544807/vector/thumbnail-image-vector-graphic.jpg?s=612x612&w=0&k=20&c=rnCKVbdxqkjlcs3xH87-9gocETqpspHFXu5dIGB4wuM=");
            }
        }
    }
}
