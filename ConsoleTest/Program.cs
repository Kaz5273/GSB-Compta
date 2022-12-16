using System;
using GSBModel;
using GSBModel.Business;
using GSBModel.Data;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dao Etat ok
            //Dao User ok
            //Dao Fichefrais ok
            //Dao FraisForfait
            //Dao LigneFraisForfait
            //Dao LigneFraisHorsForfait

            Dbal dbal = new Dbal();
            DaoUser daoUser = new DaoUser(dbal);
            DaoEtat daoEtat = new DaoEtat(dbal);
            DaoFraisForfait daoFraisForfait = new DaoFraisForfait(dbal);

            User unUser = new User(1, "test", "g,slG", "blabla", "kaz", "52 route", "73390", new DateTime(2022, 12, 15), "chateauneuf", "a131");
            Etat unEtat = new Etat(1, "Saisie clôturée");
            DaoFicheFrais daoFicheFrais = new DaoFicheFrais(dbal, daoUser, daoEtat);
            DateTime newDate = new DateTime(2022, 12, 15);
            FicheFrais uneficheFrais = new FicheFrais(218, unUser, unEtat, 32, newDate, 1000.53m, "202201");
            daoFicheFrais.SelectById(1);

            //daoUser.SelectAll();
            //Etat unEtat = new Etat(5, "test");
            //daoEtat.Delete(unEtat);
        }
    }
}