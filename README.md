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

2017.9.10 早
关于碰撞思路：
对Player和Bullet的Tag修改好，然后当OnTriggerEnter时，通过Bullet中的BulletMove脚本的GetParentName()方法
与Player的SimpleMove脚本的PlayerID对比即可，若两个相同则为己方弹幕，不予理会，否则判断为GetParentName()
所示Player造成的伤害。当碰撞时检测到玩家死亡时，也可以根据GetParentName()所示Player来增加其击杀数。
【这样可以方便游戏内容扩展，如当玩家大于等于2时，我们只需要修改玩家输入，而不需要考虑子弹来源等】
关于Bullet的parentName：
子弹设置parentName主要是为了方便追踪子弹来源和配合PlayerStatusController来对某一个玩家的子弹速度增减等
关于PlayerID随机生成(在PlayerStatusController中)：
因为考虑到游戏可能会扩展成>=2人的游戏，我们设置PlayerID可能会出现命名重复导致PlayerStatusController中的
字典的Key重复，从而PlayerStatusController不可正常运作，因此当新的Player加入时，当发现新的Player与已经存
在的Player重名时，会给它一个随机的名称【若不重名则此函数不会作用，因此不用担心】
【当真的出现重名时，目前会存在Bug：由于x,y轴的输入是根据playerID提前设置好的，因此随机的player并不会存
在于预先设好的输入类型中，从而导致上下左右不能运作->使用动态的input解决此问题】
关于TimeLimitedSkillAbstract：
此抽象方法是为了所有带延时性质的技能而准备的，实现BeforeSkill()完成技能相关操作，实现AfterSkill()完成技能
之后的相关处理【为了实现它，为SkillAbstract增加了AdditionalUpdate()虚函数，从而使其可以利用Update()】
关于DestroyCallbackAbstract：
一个弹幕是由一个父GameObject包着一群Bullet构成，因此父GameObject可以绑定ChildrenBulletParentNameSetterTool
脚本来给Bullet绑定parentName。另外ChildrenBulletParentNameSetterTool继承了DestroyCallbackAbstract，当Bullet
全部Destory时，父GameObject不可以自动消失，因此增加了DestroyCallbackAbstract来对这种情况做回调处理，另外
也可以适用于非遍历获取当前GameObject内存在的Bullet的数量等，可以提升一些效率
关于PauseMenu：
这个脚本目前用于暂停（ESC）和重置游戏（P），但是会发现暂停时重置游戏成功后，画面会变暗，这是Unity的问题，
实际Build出的游戏并无问题
------------------------------------------------------------------------------------------------------------
9.9 讨论的目标：
1.美术
-风格尝试#1 
-给出人物基本模型、子弹基本模型/地图

2.程序实现：
- 加入玩家2
- 模型大小修改
- 了解Particle Effect的添加方式和速度修改；ParticleSystem.MainModule.simulationSpeed等
- 地图需要修改，可以把随机地图变成固定的一个plane，加上围墙和简单的障碍物；
- 血量系统