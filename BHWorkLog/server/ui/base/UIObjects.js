﻿Ext.ns("Sys.DB");
Sys.DB.Address = { addrId: 'addrId', addrName: 'addrName', parentId: 'parentId', usable: 'usable' };
Sys.DB.ApplicationUser = { userid: 'userid', Username: 'Username', roleId: 'roleId', organizationId: 'organizationId', fullName: 'fullName', passWord: 'passWord', telephone: 'telephone', isTotal: 'isTotal', email: 'email', usable: 'usable', loginTimes: 'loginTimes', lastLoginTime: 'lastLoginTime', writeTime: 'writeTime', writeUser: 'writeUser', writeIp: 'writeIp', isMarry: 'isMarry', birthday: 'birthday', household: 'household', oldHome: 'oldHome', nowLiveHome: 'nowLiveHome', intoCompanyDate: 'intoCompanyDate', workTotalYear: 'workTotalYear', still: 'still', maxEducation: 'maxEducation', maxEduCollege: 'maxEduCollege', maxEduLeaveTime: 'maxEduLeaveTime', workExperiences: 'workExperiences', studyExperiences: 'studyExperiences', photoUrl: 'photoUrl' };
Sys.DB.BookBelongTo = { belongtoId: 'belongtoId', fullname: 'fullname', usable: 'usable', sort: 'sort' };
Sys.DB.BookDomainType = { domainTypeId: 'domainTypeId', domainName: 'domainName', usable: 'usable', remark: 'remark', sort: 'sort' };
Sys.DB.BookFromCountry = { countryId: 'countryId', countryName: 'countryName', usable: 'usable', sort: 'sort' };
Sys.DB.BookInformation = { bookId: 'bookId', domainTypeId: 'domainTypeId', publisherId: 'publisherId', belongtoId: 'belongtoId', countryId: 'countryId', userId: 'userId', bookTitle: 'bookTitle', author: 'author', translator: 'translator', bookurl: 'bookurl', publishDate: 'publishDate', isbn: 'isbn', buyTime: 'buyTime', paymoney: 'paymoney', writeTime: 'writeTime' };
Sys.DB.BookPublisher = { publisherId: 'publisherId', publisherName: 'publisherName', address: 'address', usable: 'usable', sort: 'sort' };
Sys.DB.ErrorLogs = { errorId: 'errorId', userid: 'userid', writeIp: 'writeIp', writeTime: 'writeTime', Content: 'Content' };
Sys.DB.EventLogs = { eventId: 'eventId', userid: 'userid', writeIp: 'writeIp', eventType: 'eventType', writeTime: 'writeTime', Content: 'Content' };
Sys.DB.Menu = { menuId: 'menuId', currentId: 'currentId', parentId: 'parentId', menuName: 'menuName', iconCls: 'iconCls', htmlurl: 'htmlurl', eventName: 'eventName', sort: 'sort', usable: 'usable' };
Sys.DB.MenuFunctionPoint = { functionId: 'functionId', menuId: 'menuId', functionPointName: 'functionPointName', eventName: 'eventName', sort: 'sort', remark: 'remark', usable: 'usable' };
Sys.DB.Organization = { organizationId: 'organizationId', userid: 'userid', organizationName: 'organizationName', currentId: 'currentId', parentId: 'parentId', usable: 'usable', writeIp: 'writeIp', writeTime: 'writeTime' };
Sys.DB.RoleControlFunctionPoint = { setId: 'setId', functionId: 'functionId', roleId: 'roleId', userid: 'userid', writeIp: 'writeIp', writeTime: 'writeTime' };
Sys.DB.RoleControlMenu = { setId: 'setId', menuId: 'menuId', roleId: 'roleId', userid: 'userid', writeIp: 'writeIp', writeTime: 'writeTime' };
Sys.DB.SiteInformation = { siteId: 'siteId', writeUser: 'writeUser', copyrightCompany: 'copyrightCompany', companyTel: 'companyTel', companyEmail: 'companyEmail', belongtoCompany: 'belongtoCompany', belongtoTel: 'belongtoTel', belongtoEmail: 'belongtoEmail', createTime: 'createTime', updated: 'updated', registerTitle: 'registerTitle', registerInformation: 'registerInformation', logoPath: 'logoPath', writeTime: 'writeTime', writeIp: 'writeIp' };
Sys.DB.SystemRole = { roleId: 'roleId', roleName: 'roleName', usable: 'usable', remark: 'remark', sort: 'sort' };
Sys.DB.UsbKey = { keyId: 'keyId', userid: 'userid', writeUserid: 'writeUserid', fullname: 'fullname', giveoutTime: 'giveoutTime', giveoutPerson: 'giveoutPerson', usable: 'usable', writeTime: 'writeTime', writeIp: 'writeIp' };
Sys.DB.WLOGMission = { missionId: 'missionId', summaryId: 'summaryId', writeUser: 'writeUser', projectId: 'projectId', missionBH: 'missionBH', missionName: 'missionName', missionRemark: 'missionRemark', planned: 'planned', plantimelimit: 'plantimelimit', outputResult: 'outputResult', startDate: 'startDate', reviewState: 'reviewState', missionState: 'missionState', deleted: 'deleted', usable: 'usable', updated: 'updated', deleteTime: 'deleteTime', writeTime: 'writeTime', writeIp: 'writeIp' };
Sys.DB.WLOGPersonLog = { missionId: 'missionId', logId: 'logId', writeUser: 'writeUser', projectItem: 'projectItem', logContent: 'logContent', logDate: 'logDate', workState: 'workState', workResult: 'workResult', isMission: 'isMission', submited: 'submited', deleted: 'deleted', deleteTime: 'deleteTime', usable: 'usable', writeTime: 'writeTime', writeIp: 'writeIp' };
Sys.DB.WLOGProjectTree = { parentId: 'parentId', currentId: 'currentId', writeUser: 'writeUser', dirName: 'dirName', usable: 'usable', writeIp: 'writeIp', writeTime: 'writeTime' };
Sys.DB.WLOGWeekSummary = { summaryId: 'summaryId', writeUser: 'writeUser', startDate: 'startDate', endDate: 'endDate', weekBH: 'weekBH', submited: 'submited', submitTime: 'submitTime', writeTime: 'writeTime', writeIp: 'writeIp' };
Sys.DB.Computer = { computerId: 'computerId', userName: 'userName', userIp: 'userIp', MACAddress: 'MACAddress', IpUseStatus: 'IpUseStatus', workStatus: 'workStatus', computerType: 'computerType', writeUser: 'writeUser', writeTime: 'writeTime', writeIp: 'writeIp', remark: 'remark' };
Sys.DB.CollectType = { collectTypeId: 'collectTypeId', releaseNo: 'releaseNo', releaseType: 'releaseType', releaseTime: 'releaseTime', writeUser: 'writeUser', writeTime: 'writeTime', writeIp: 'writeIp' };
Sys.DB.InsideCollect = { insideCollectId: 'insideCollectId', collectTypeId: 'collectTypeId', systemName: 'systemName', fileNo: 'fileNo', fileTime: 'fileTime', writeUser: 'writeUser', writeTime: 'writeTime', writeIp: 'writeIp' };
Sys.DB.ProductionCollect = { productionCollectId: 'productionCollectId', collectTypeId: 'collectTypeId', systemName: 'systemName', fileNo: 'fileNo', fileTime: 'fileTime', writeUser: 'writeUser', writeTime: 'writeTime', writeIp: 'writeIp' };
Sys.DB.ProjectCollect = { projectCollectId: 'projectCollectId', collectTypeId: 'collectTypeId', projectItemName: 'projectItemName', systemName: 'systemName', fileNo: 'fileNo', fileTime: 'fileTime', writeUser: 'writeUser', writeTime: 'writeTime', writeIp: 'writeIp' };