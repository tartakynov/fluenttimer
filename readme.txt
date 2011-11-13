examples:
1)	FluentTimer.Each(10).Seconds().Call(() => Console.WriteLine("hello!"));        
2)	FluentTimer
		.Each(10).Minutes()
		.And(30).Seconds()
		.Call(() => Console.WriteLine("hello!"));     
   