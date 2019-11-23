using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApiFrame.Common;
using System.Data;
using ApiFrame.DataAccess;
using Npgsql;
using System.Data.SqlClient;

namespace ApiFrame.Bussiness
{
    public class TimeKeeping
    {
        //public static SeabRes process(SeabReq request)
        //{
        //    NpgsqlConnection conn = ScopeConnection.Instance.GetConnection();
        //    //IDbConnection oracleconn = ScopeConnection.Instance.GetOracleConnection();

        //    //IDbTransaction tran = conn.BeginTransaction();
        //    //Oracle.DataAccess.Client.OracleTransaction transacion = (Oracle.DataAccess.Client.OracleTransaction)oracleconn.BeginTransaction();

        //    //SqlConnection zkConn = ScopeConnection.Instance.GetZKConnection();

        //    SeabRes response = Utils.CreateReponse(request, "000", "Successfully completed");
        //    response.body = new BodyRes();
        //    response.sign = request.sign;

        //    #region Check Validate chung cho mọi request
        //    HeaderReq headerReq = request.header;
        //    BodyReq bodyReq = request.body;
        //    if (headerReq == null || bodyReq == null)
        //        return Utils.CreateCommonError(response, Constants.E103);

        //    if (string.IsNullOrEmpty(headerReq.reqType))
        //        return Utils.CreateBlankError(response, "reqType");
        //    if (string.IsNullOrEmpty(headerReq.api))
        //        return Utils.CreateBlankError(response, "api");
        //    if (string.IsNullOrEmpty(headerReq.apiKey))
        //        return Utils.CreateBlankError(response, "apiKey");
        //    if (string.IsNullOrEmpty(headerReq.priority))
        //        return Utils.CreateBlankError(response, "priority");
        //    if (string.IsNullOrEmpty(headerReq.channel))
        //        return Utils.CreateBlankError(response, "channel");
        //    if (string.IsNullOrEmpty(headerReq.subChannel))
        //        return Utils.CreateBlankError(response, "subChannel");
        //    if (string.IsNullOrEmpty(headerReq.location))
        //        return Utils.CreateBlankError(response, "location");
        //    if (string.IsNullOrEmpty(headerReq.context))
        //        return Utils.CreateBlankError(response, "context");
        //    if (string.IsNullOrEmpty(headerReq.trusted))
        //        return Utils.CreateBlankError(response, "trusted");
        //    if (string.IsNullOrEmpty(headerReq.userID))
        //        return Utils.CreateBlankError(response, "userID");
        //    if (string.IsNullOrEmpty(headerReq.dn))
        //        return Utils.CreateBlankError(response, "dn");
        //    if (string.IsNullOrEmpty(headerReq.requestAPI))
        //        return Utils.CreateBlankError(response, "requestAPI");
        //    if (string.IsNullOrEmpty(headerReq.requestNode))
        //        return Utils.CreateBlankError(response, "requestNode");

        //    if (string.IsNullOrEmpty(headerReq.requestNode))
        //        return Utils.CreateBlankError(response, "requestNode");

        //    if (bodyReq.command != Constants.Command.category)
        //        return Utils.CreateCommonError(response, Constants.E001);

            

        //    #endregion

        //    #region LogRequest
        //    //request.header.requestID = DS_SystemPermission.LogRequest(conn, request);
        //    //response.header.requestID = request.header.requestID;
        //    #endregion

        //    #region Xử lý

        //    try
        //    {
        //        switch (bodyReq.command)
        //        {
        //            case Constants.Command.category:
        //                CategoryProcess(bodyReq, ref response);
        //                break;

        //            case Constants.Command.open_phase:
        //                break;

        //            case Constants.Command.over_time:
        //                break;

        //            case Constants.Command.bussiness_time:
        //                break;

        //            case Constants.Command.timesheettimekeeping:
        //                break;

        //            case Constants.Command.leavetimekeeping:
        //                break;

        //            case Constants.Command.verifytimekeeping:
        //                break;

        //            case Constants.Command.addtimekeeping:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        response = Utils.CreateReponse(request, "99", ex.Message);
        //    }

        //    #endregion

        //    #region LogResponse

        //    try
        //    {
        //        //DS_SystemPermission.LogResponse(conn, response);
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    #endregion

        //    return response;
        //}

        //#region SubProcess
        //public static void CategoryProcess(BodyReq bodyRequest, ref SeabRes response)
        //{
        //    #region Check Validate
        //    if (bodyRequest.type != Constants.Type.Create && bodyRequest.type != Constants.Type.Update
        //        && bodyRequest.type != Constants.Type.Delete && bodyRequest.type != Constants.Type.Approve
        //        && bodyRequest.type != Constants.Type.Getlist)
        //    {
        //        response = Utils.CreateCommonError(response, Constants.E002);
        //        return;
        //    }
        //    #endregion

        //    // check details luôn phải có 1 ông name = code để làm key
        //    if (bodyRequest.type != Constants.Type.Getlist)
        //    {
        //        var lstCode = bodyRequest.details.Where(e => e.name == "code").ToList();
        //        if (lstCode == null || lstCode.Count == 0)
        //        {
        //            response = Utils.CreateCommonError(response, Constants.E003);
        //            return;
        //        }
        //        if (lstCode.Count > 1)
        //        {
        //            response = Utils.CreateCommonError(response, Constants.E004);
        //            return;
        //        }
        //        foreach (var itemdetails in bodyRequest.details)
        //            itemdetails.code = lstCode[0].value;
        //    }
            

        //    switch (bodyRequest.type)
        //    {
        //        case Constants.Type.Create:
        //            var danhMucInsert = Constants.lstDanhMuc.Where(e => e.details[0].code == bodyRequest.details[0].code && e.category == bodyRequest.category).FirstOrDefault();
        //            if (danhMucInsert != null)
        //            {
        //                response = Utils.CreateCommonError(response, Constants.E005);
        //                return;
        //            }
        //            //Xử lý cho từng danh mục 
        //            Constants.lstDanhMuc.Add(bodyRequest);
        //            break;
        //        case Constants.Type.Update:
        //            var danhMucUpdate = Constants.lstDanhMuc.Where(e => e.details[0].code == bodyRequest.details[0].code && e.category == bodyRequest.category).FirstOrDefault();
        //            if (danhMucUpdate == null)
        //            {
        //                response = Utils.CreateCommonError(response, Constants.E006);
        //                return;
        //            }
        //            Constants.lstDanhMuc.Remove(danhMucUpdate);
        //            Constants.lstDanhMuc.Add(bodyRequest);
        //            break;
        //        case Constants.Type.Delete:
        //            var danhMucDelete = Constants.lstDanhMuc.Where(e => e.details[0].code == bodyRequest.details[0].code && e.category == bodyRequest.category).FirstOrDefault();
        //            if (danhMucDelete == null)
        //            {
        //                response = Utils.CreateCommonError(response, Constants.E006);
        //                return;
        //            }
        //            Constants.lstDanhMuc.Remove(danhMucDelete);
        //            break;
        //        case Constants.Type.Approve:
        //            break;
        //        case Constants.Type.Getlist:
        //            var listBody = (from item in Constants.lstDanhMuc
        //                            where item.category == bodyRequest.category
        //                            && item.active == bodyRequest.active
        //                            && item.status == bodyRequest.status
        //                            select item).ToList();
        //            if (listBody == null || listBody.Count == 0)
        //                return;
        //            response.body.command = "category_Getlist";
        //            response.body.category = bodyRequest.category;
        //            response.body.lists = new List<ListCategory>();
        //            foreach (var itemCategory in listBody)
        //            {
        //                List<CateforyDetails> lstCategory = new List<CateforyDetails>();
        //                lstCategory.AddRange(itemCategory.details);
        //                response.body.lists.Add(new ListCategory() { data = lstCategory });
        //            }
        //            break;
        //    }
        //}

        //#endregion
    }
}
