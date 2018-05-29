# Homework7: Car smoke


----------


本次作业我选择实现的是完善汽车尾气。
[视频地址](https://pan.baidu.com/s/1eg2C9ruMWAuoJfcQ3pxoBA)  [参考博客](https://blog.csdn.net/u010930289/article/details/50831547)


----------

 1. 首先，先在unity官网下载Standard Assests包，[下载教程](https://blog.csdn.net/A1032453509/article/details/73222845)，并且在项目中import PaticleSystem和Vehicles两个大类。
 2. 将Car拖入，并将smoke装载在上面，运行发现，尽管设置了loop，smoke还是会在一定时间后自动消失，发现是挂在在smoke上的ParticleSystemDestroyer文件导致的，取消挂载该文件就可以解决。
 3. 将烟的位置稍加变化，使得其喷出位置为车的后部，再调整smoke的Force over Lifetime，使得烟一直向汽车的后方喷出
 ![Force over Lifetime](https://github.com/zhongshuaihui/3D-game-learning/blob/master/homework7/Force%20over%20Lifetime.JPG)
 4. smoke自带的Color over Lifetime和Size over Lifetime都比较合适，就不需要再多加改变了，所以接下来就只需要进行微调，比如更改每个粒子的生命周期，因为太长了的话也不太符合实际，所以我就更改为2.5-4秒。
 5. 最后，将老师所提供的PartScriptTestCS文件装载到smoke上，这样就可以通过调整engineRevs和exhaustRate的值来模拟不同类型的引擎和磨损程度，引擎越耗油或磨损程度越高，其值可以设的更高，smoke也就越黑。<br>
 节能引擎，磨损程度低：<br>
 ![clean](https://github.com/zhongshuaihui/3D-game-learning/blob/master/homework7/clean.JPG)<br>
 耗油引擎，磨损程度高：<br>
 ![dirty](https://github.com/zhongshuaihui/3D-game-learning/blob/master/homework7/dirty.JPG)

