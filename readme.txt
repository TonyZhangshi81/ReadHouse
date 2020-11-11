结构说明

1. Core（基础层）：提供系统中与业务无关的基础设施功功能
	RHF.Core.Data：数据组件，提供与业务无关的EF数据上下文，单元操作，仓储操作，EF二级缓存等功能的定义与实现
	RHF.Core.Tools：工具组件，提供通用辅助操作功能，扩展方法，异常定义，日志记录定义与实现等功能
2. Business (业务层)：提供与业务实体密切相关的业务功能
	RHF.Business.Models：业务实体模型，定义用于系统核心业务实现的数据模型的定义
	RHF.Business.Data：业务数据访问定义与实现：提供与业务相关的数据访问功能的实体映射，数据迁移，仓储操作的定义与实现
	RHF.Business.Core：业务核心功能定义与实现：提交与客户端（网站，桌面端，移动端）无关的业务逻辑的实现，业务核心层主要特征如下：
		a. 此层是业务逻辑处理的核心，数据载体为业务实体
		b. 此层所有类为抽象类，需要在相应的客户端（网站，桌面端，移动端）进行继承后才能被展现层调用
		c. 此层要做到客户端（网站、桌面端、移动端）状态（如网站的Cookie，Session等）无关性，所有客户端特有的业务都要在相应的派生层中进行处理，转换为状态无关后再调用此层进行运算
		d. 对于不同客户端（网站、桌面端、移动端）的数据，只需要转换为业务实体即可调用此层代码进行运算，解决相同业务在不同客户端代码重复的问题
3. Application (应用层)
	RHF.Demo.Site.Models：网站业务视图模型：定义用于网站业务实现的视图模型的定义
	RHF.Demo.Site：网站业务实现，此项目继承于RHF.Demo.Core，主要职能如下：
		a. 对业务执行权限进行检查
		b. 负责把从网站接收的业务视图实体转换为核心业务模型，传给业务核心层进行业务处理
		c. 处理与Http密切相关的数据（Session、Cookie等），处理成与Http状态无关后再交由核心层进行处理
4. Presentation (展现层)
	RHF.Demo.Client.Consoles：业务控制台，可对功能代码段，核心业务等功能进行调用测试。
	RHF.Demo.Site.Web：网站UI展现
		a. 对Action执行权限进行检查
		b. 接收用户输入并转交给站点业务层进行处理
		c. 记录功能操作的日志记录与异常日志




LINQ to SQL语句
http://kb.cnblogs.com/page/42467/


EF架构~基于EF数据层的实现
http://www.cnblogs.com/lori/p/4040951.html


Log4Net在Web项目中的配置和使用
http://jingyan.baidu.com/article/d45ad148bb23b269552b802a.html
Log4Net使用指南
http://www.cnblogs.com/dragon/archive/2005/03/24/124254.html