using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace InvertedListView
{
    public class MessageCollection : ObservableCollection<MessageInfo>, ISupportIncrementalLoading
    {
        private readonly CoreDispatcher _dispatcher = Window.Current.Dispatcher;

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            return Task.Run(async () =>
                {
                    await _dispatcher
                        .RunAsync
                        (CoreDispatcherPriority.Normal,
                            () =>
                            {
                                for (var i = 0; i < 10; i++)
                                {
                                    Add(new MessageInfo {Name = "User", Message = $"Old message {Count + 1}"});
                                }
                            });

                    if (Count > 100)
                    {
                        HasMoreItems = false;
                    }

                    return new LoadMoreItemsResult {Count = 10};

                })
                .AsAsyncOperation();
        }

        public bool HasMoreItems { get; private set; } = true;
    }
}