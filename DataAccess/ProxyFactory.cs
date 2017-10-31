using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace DataAccess
{
	public class ProxyFactory
	{
		public static INetflixProxy CreateNetflixProxy()
		{
			if (NetworkInterface.GetIsNetworkAvailable())
				return new NetflixProxy();
			return new NetflixProxyStub();
		}
	}
}
