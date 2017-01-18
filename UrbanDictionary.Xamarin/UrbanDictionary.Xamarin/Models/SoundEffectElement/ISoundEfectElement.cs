using System;
using System.Threading.Tasks;

namespace UrbanDictionary.Models
{
    public interface ISoundEffectElement
    {
        Task<SoundEffectResult> PlayAsync(Uri uriSource);
    }
}
