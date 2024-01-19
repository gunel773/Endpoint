

using ThreadTaskAwaitSync.Helpers.Utilities;

Helper helper = new Helper();
var datas = await helper.GetDataHttp(d => d.id == 1 || d.id == 10 || d.id == 100);


