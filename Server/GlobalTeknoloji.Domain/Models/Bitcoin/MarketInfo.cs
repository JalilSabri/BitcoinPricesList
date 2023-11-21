using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlobalTeknoloji.Domain.Models.Common;

namespace GlobalTeknoloji.Domain.Models.Bitcoin;

[Table("tblMarketInfo")]
public class MarketInfo : BaseEntity
{
    public string CoinDate { get; set; } = DateTime.Now.ToShortDateString();

    public string CoinTime { get; set; } = DateTime.Now.ToLongTimeString();

    public string? CoinLabel { get; set; }

    public string? CoinName { get; set; }

    [Required]
    public double CoinPrice { get; set; }
}
