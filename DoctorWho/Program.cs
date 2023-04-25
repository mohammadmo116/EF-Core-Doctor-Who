// See https://aka.ms/new-console-template for more information
using DoctorWho.Db;
using DoctorWho.Db.DbFunctions;
using DoctorWho.Db.DbViews;
using DoctorWho.Db.DTOs;
using DoctorWho.Db.Migrations;
using DoctorWho.Db.Models;
using DoctorWho.Db.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


using (DoctorWhoCoreDbContext context = new DoctorWhoCoreDbContext())
{


    Console.WriteLine("***fnEnemies***");
    Console.WriteLine(fnEnemies(4));
    Console.WriteLine();
    Console.WriteLine("***fnCompanions***");
    Console.WriteLine(fnCompanions(4));
    Console.WriteLine();
    Console.WriteLine("***viewEpisodes***");
    var viewEpisodesData = viewEpisodes();
    viewEpisodesData.ForEach(a => Console.Write(
        $"Author: {a.AuthorName}   Doctor: {a.DoctorName}" +
        $"\n*Companions: {a.Companions}      *Enemies: {a.Enemies}" +
        $"\n*EpisodeId: {a.EpisodeId}      *SeriesNumber: {a.SeriesNumber}   *EpisodNumber: {a.EpisodNumber}" +
        $"\n*EpisodType: {a.EpisodType}     *Title: {a.Title}" +
        $"\n*EpisodDate: {a.EpisodDate}  " +
        $"\n*Notes: {a.Notes}" +
        $"\n*DoctorId: {a.DoctorId}        *AuthorId: {a.AuthorId}" +
        $"\n" +
        $"-----------------------\n"
        )
    );
    Console.WriteLine();
    Console.WriteLine("***TopThreeEpisodesEnemies***");
    var TopThreeEpisodesEnemiesData = TopThreeEpisodesEnemies();
    TopThreeEpisodesEnemiesData.ForEach(a => Console.Write(a.ToString()));
    Console.WriteLine("-----------");
    Console.WriteLine("***TopThreeEpisodesCompanions***");
    var spTopThreeEpisodesCompanionsData = TopThreeEpisodesCompanions();
    spTopThreeEpisodesCompanionsData.ForEach(a => Console.Write(a.ToString()));

    Console.WriteLine();

    string fnCompanions(int EpisodeId)
    {

        return context.FnCompanions.FromSqlInterpolated($"SELECT dbo.fnCompanions({EpisodeId}) as Companions").FirstOrDefault().companions;
    }

    string fnEnemies(int EpisodeId)
    {
        return context.FnEnemies.FromSqlInterpolated($"SELECT dbo.fnEnemies({EpisodeId}) as Enemies").FirstOrDefault().Enemies;


    }
    List<ViewEpisodes> viewEpisodes()
    {
        return context.ViewEpisodes.ToList();

    }
    List<spTopThreeEpisodeEnemies> TopThreeEpisodesEnemies()
    {
        return context.spTopThreeEpisodeEnemies.ToList();


    }
    List<spTopThreeEpisodeCompanions> TopThreeEpisodesCompanions()
    {
        return context.spTopThreeEpisodeCompanions.ToList();


    }

}

