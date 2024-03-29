﻿using Blazored.LocalStorage;
using FightingFantasyCompanion.Shared.Models;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace FightingFantasyCompanion.Shared.Services
{
    public class AdventureService:IAdventureService
    {
        private readonly ILocalStorageService _localStorageService;
        public AdventureService(ILocalStorageService localStorageService) {
            _localStorageService=localStorageService;
        }

        public async Task<List<Adventure>> GetAll()
        {
            List<Adventure> adventures = new List<Adventure>();

            var keys = await _localStorageService.KeysAsync();
            foreach (var key in keys)
            {
                string? json = await _localStorageService.GetItemAsync<string>(key);
                if (!string.IsNullOrEmpty(json))
                {
                    Adventure? adventure = JsonSerializer.Deserialize<Adventure>(json);
                    if (adventure != null) adventures.Add(adventure);
                }
            }

            return adventures.OrderByDescending(a=>a.CreationDate).ToList();
        }

        public async Task<Adventure?> GetById(string Id)
        {
            string? json = await _localStorageService.GetItemAsync<string>(Id);
            if (!string.IsNullOrEmpty(json))
            {
                Adventure? adventure = JsonSerializer.Deserialize<Adventure>(json);
                if (adventure != null) return adventure;
            }

            return null;
        }

        public async Task DeleteAdventure(string Id)
        {
            await _localStorageService.RemoveItemAsync(Id);
        }

        public async Task SaveAdventure(Adventure adventure)
        {
            adventure.LastModificationDate = DateTime.Now;
            await _localStorageService.SetItemAsync(adventure.Id, JsonSerializer.Serialize(adventure));
        }
    }
}
