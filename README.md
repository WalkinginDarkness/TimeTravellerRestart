# TimeTravellerRestart

共享文档：https://docs.google.com/document/d/1IccPpO9cjHtJizm7c5MjO9l2zbMTQ2Z7gpZuUYLkYIc/edit?usp=sharing


2017.9.3

3D的同屏多人射击游戏；
风格可以参考 https://indienova.com/groups/35

通过速度和动画速度的改变来带来时间流速变慢的错觉；

基本框架：

八向行走
八项子弹发射
技能1：通过慢速的子弹位移（与子弹交换位置）；
技能2：通过时间的能力加速（暂定加速射击+加速闪避）；


2017.9.3 晚 版本：网格地图+基本行走转向；

//网格状地图（经过试验后暂时取消）

2017.9.4 晚：修改移动ing

期待的内容：
通过速度和动画速度的改变来带来时间流速变慢的错觉；有一个速度作为全局变量：
可以改变：
动画的速度
粒子效果的速度（ParticleSystem.MainModule.simulationSpeed这个API）
类似于Time Locker这一种慢放的效果

效果：
