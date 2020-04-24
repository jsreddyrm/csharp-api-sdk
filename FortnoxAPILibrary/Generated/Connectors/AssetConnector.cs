using System.Text.RegularExpressions;
using FortnoxAPILibrary;
using FortnoxAPILibrary.Entities;

using System.Threading.Tasks;

// ReSharper disable UnusedMember.Global

namespace FortnoxAPILibrary.Connectors
{
    /// <remarks/>
    public class AssetConnector : EntityConnector<Asset, EntityCollection<AssetSubset>, Sort.By.Asset?>, IAssetConnector
	{
	    /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter("filter")]
		public Filter.Asset? FilterBy { get; set; }


        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Description { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        [SearchParameter]
		public string Type { get; set; }

		/// <remarks/>
		public AssetConnector()
		{
			Resource = "assets";
		}
		/// <summary>
		/// Find a asset based on id
		/// </summary>
		/// <param name="id">Identifier of the asset to find</param>
		/// <returns>The found asset</returns>
		public Asset Get(string id)
		{
            FixResponseContent = (json) => new Regex("Assets").Replace(json, "Asset", 1);

            var result = BaseGet(id);

            FixResponseContent = null;
            return result;
        }

		/// <summary>
		/// Updates a asset
		/// </summary>
		/// <param name="asset">The asset to update</param>
		/// <returns>The updated asset</returns>
		public Asset Update(Asset asset)
        {
            var id = asset.Id;
            asset.Id = null;
            FixResponseContent = (json) => new Regex("Assets").Replace(json, "Asset", 1);

            var result = BaseUpdate(asset, id);

            FixResponseContent = null;
            asset.Id = id;
            return result;
		}

		/// <summary>
		/// Creates a new asset
		/// </summary>
		/// <param name="asset">The asset to create</param>
		/// <returns>The created asset</returns>
		public Asset Create(Asset asset)
        {
            FixResponseContent = (json) => new Regex("Assets").Replace(json, "Asset", 1);

            var result = BaseCreate(asset);

            FixResponseContent = null;
            return result;
        }

		/// <summary>
		/// Deletes a asset
		/// </summary>
		/// <param name="id">Identifier of the asset to delete</param>
		public void Delete(string id)
		{
			BaseDelete(id.ToString());
		}

		/// <summary>
		/// Gets a list of assets
		/// </summary>
		/// <returns>A list of assets</returns>
		public EntityCollection<AssetSubset> Find()
		{
			return BaseFind();
		}

		public async Task<EntityCollection<AssetSubset>> FindAsync()
		{
			return await BaseFind();
		}
		public async Task DeleteAsync(string id)
		{
			await BaseDelete(id.ToString());
		}
		public async Task<Asset> CreateAsync(Asset asset)
        {
            FixResponseContent = (json) => new Regex("Assets").Replace(json, "Asset", 1);

            var result = await BaseCreate(asset);

            FixResponseContent = null;
            return result;
        }
		public async Task<Asset> UpdateAsync(Asset asset)
        {
            var id = asset.Id;
            asset.Id = null;
            FixResponseContent = (json) => new Regex("Assets").Replace(json, "Asset", 1);

            var result = await BaseUpdate(asset, id);

            FixResponseContent = null;
            asset.Id = id;
            return result;
		}

		/// <summary>
		/// Creates a new asset
		/// </summary>
		/// <param name="asset">The asset to create</param>
		/// <returns>The created asset</returns>
		public async Task<Asset> GetAsync(string id)
		{
            FixResponseContent = (json) => new Regex("Assets").Replace(json, "Asset", 1);

            var result = await BaseGet(id);

            FixResponseContent = null;
            return result;
        }

		/// <summary>
		/// Updates a asset
		/// </summary>
		/// <param name="asset">The asset to update</param>
		/// <returns>The updated asset</returns>
	}
}
