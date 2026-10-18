using ZooApp.Models;

namespace ZooApp.Repositories
{
    public class AnimalRepository
    {
        // Lista que guarda os animais na memória
        private List<Animal> animais = new List<Animal>();

        // Próximo Id a ser usado
        private int proximoId = 4;

        // Cria 3 animais de exemplo quando o sistema inicia
        public AnimalRepository()
        {
            Animal a1 = new Animal();
            a1.Id = 1;
            a1.Nome = "Simba";
            a1.Especie = "Leão";
            a1.DataChegada = new DateTime(2022, 3, 15);
            a1.Habitat = Habitat.Savana;
            a1.Peso = 190.5m;
            a1.Dieta = "Carnívoro";
            animais.Add(a1);

            Animal a2 = new Animal();
            a2.Id = 2;
            a2.Nome = "Madalena";
            a2.Especie = "Girafa";
            a2.DataChegada = new DateTime(2021, 7, 2);
            a2.Habitat = Habitat.Savana;
            a2.Peso = 800m;
            a2.Dieta = "Herbívoro";
            animais.Add(a2);

            Animal a3 = new Animal();
            a3.Id = 3;
            a3.Nome = "Pingo";
            a3.Especie = "Pinguim";
            a3.DataChegada = new DateTime(2024, 1, 20);
            a3.Habitat = Habitat.Polar;
            a3.Peso = 4.2m;
            a3.Dieta = "Carnívoro";
            animais.Add(a3);
        }

        // Devolve todos os animais, ou só os que têm o nome da busca
        public List<Animal> Listar(string? busca)
        {
            if (string.IsNullOrWhiteSpace(busca))
            {
                return animais;
            }

            List<Animal> resultado = new List<Animal>();
            foreach (Animal a in animais)
            {
                if (a.Nome.ToLower().Contains(busca.Trim().ToLower()))
                {
                    resultado.Add(a);
                }
            }
            return resultado;
        }

        // Procura um animal pelo Id
        public Animal? Obter(int id)
        {
            foreach (Animal a in animais)
            {
                if (a.Id == id)
                {
                    return a;
                }
            }
            return null;
        }

        // Verifica se ja existe outro animal com o mesmo nome
        public bool ExisteNome(string? nome, int idIgnorar)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return false;
            }

            foreach (Animal a in animais)
            {
                if (a.Id != idIgnorar && a.Nome.ToLower() == nome.Trim().ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        // Cadastra um novo animal
        public void Adicionar(Animal animal)
        {
            animal.Id = proximoId;
            proximoId++;
            animais.Add(animal);
        }

        // Troca o animal antigo pelo editado
        public void Atualizar(Animal animal)
        {
            for (int i = 0; i < animais.Count; i++)
            {
                if (animais[i].Id == animal.Id)
                {
                    animais[i] = animal;
                }
            }
        }

        // Remove o animal pelo Id
        public void Remover(int id)
        {
            Animal? animal = Obter(id);
            if (animal != null)
            {
                animais.Remove(animal);
            }
        }
    }
}