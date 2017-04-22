using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanDictionary.Models;
using UrbanDictionary.Xamarin.Core.Collections;
using UrbanDictionary.Xamarin.DataAccess;

namespace UrbanDictionary.Xamarin.ViewModels
{
    public class DefinitionViewModel : MvxViewModel
    {
        public const string DefinitionWord = "DefinitionWord";
        private IDayWordsProvider _dayWordsProvider;
        private int pageNumber = 1;

        public DefinitionViewModel(IDayWordsProvider dayWordsProvider)
        {
            _dayWordsProvider = dayWordsProvider;
            RefreshCommand = new MvxCommand(RefreshExecute);
        }

        public MvxCommand RefreshCommand { get; }

        private async void RefreshExecute()
        {
            try
            {
                IsRefreshing = true;
                await Task.Delay(2500);
                var data = await _dayWordsProvider.LoadDefinitionAsync(Definition, 1);
                Data.Clear();
                Data.HasMoreItems = true;
                Data.AddRange(data);
                pageNumber = 1;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                IsRefreshing = false;
            }

            RaisePropertyChanged(nameof(IsRefreshing));
        }

        private async Task<IList<WordOfDay>> LoadMoreItems()
        {
            var data = await _dayWordsProvider.LoadDefinitionAsync(Definition, pageNumber++);
            Data.HasMoreItems = data.HasMoreItems;
            return data;
        }

        public IncrementalCollection<WordOfDay> Data { get; private set; }
        public bool IsRefreshing { get; private set; }
        public string Definition { get; private set; }

        protected override void InitFromBundle(IMvxBundle parameters)
        {
            base.InitFromBundle(parameters);

            Definition = parameters.Data[DefinitionWord];
            Data = new IncrementalCollection<WordOfDay>(LoadMoreItems);
        }
    }
}
