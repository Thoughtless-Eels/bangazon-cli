using System;
using BangazonCli;
using System.Collections.Generic;
using Xunit;

namespace BangazonCli.Test
{
    public class ProductOrderJoin_Should
    {
        private ProductOrderJoin _productOrderJoin;
        public ProductOrderJoin_Should () {
            _productOrderJoin = new ProductOrderJoin (
                "1",
                "1",
                "1"
            );
        }
        [Fact]
        public void createProductOrderJoinObj () {
            
            Assert.Equal("1", _productOrderJoin.ProductOrderJoinId);
            Assert.Equal("1", _productOrderJoin.ProductId);
            Assert.Equal("1", _productOrderJoin.OrderId);
            
        }
    }
}