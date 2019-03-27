using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Xpo;
using DevExpress.Data.Filtering;
using DevExpress.Web;

namespace XpoWebApplication {
    public partial class _Default : System.Web.UI.Page {

        protected void Page_Init(object sender, EventArgs e) {
            if (CriteriaOperator.GetCustomFunction(AccentInsensitiveFilterStatic.Name) == null)
                CriteriaOperator.RegisterCustomFunction(new AccentInsensitiveFilterOperator());
            XpoDataSource1.Session = XpoHelper.GetNewSession();
        }

        protected void ASPxGridView1_ProcessColumnAutoFilter(object sender, ASPxGridViewAutoFilterEventArgs e) {
            if (e.Kind != GridViewAutoFilterEventKind.CreateCriteria)
                return;
            CriteriaOperator co = CriteriaOperator.Parse(ASPxGridView1.FilterExpression);
            FindAndRemoveCustomOperator(ref co, e.Column.FieldName);
            FunctionOperator fo = null;
            if (e.Value.Length > 0)
                fo = new FunctionOperator(FunctionOperatorType.Custom, AccentInsensitiveFilterStatic.Name, e.Value, new OperandProperty(e.Column.FieldName));
            if (!ReferenceEquals(co, null) || !ReferenceEquals(fo, null))
                e.Criteria = MergeCriterias(co, fo);
            else 
                e.Criteria = null;
        }
        protected void ASPxGridView1_AutoFilterCellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e) {
            if (string.IsNullOrEmpty(ASPxGridView1.FilterExpression) || !ASPxGridView1.FilterExpression.Contains(AccentInsensitiveFilterStatic.Name))
                return;
            var co = CriteriaOperator.Parse(ASPxGridView1.FilterExpression);
            var fo = FindAndRemoveCustomOperator(ref co, e.Column.FieldName);
            if (ReferenceEquals(fo, null))
                return;
            var oValue = fo.Operands[1] as OperandValue;
            if (ReferenceEquals(oValue, null))
                return;
            e.Editor.Value = oValue.Value.ToString();
        }

        protected CriteriaOperator MergeCriterias(CriteriaOperator co, FunctionOperator fo) {
            if (ReferenceEquals(fo, null))
                return co;
            if (ReferenceEquals(co, null))
                return fo;
            var go = co as GroupOperator;
            if (ReferenceEquals(go, null) || go.OperatorType != GroupOperatorType.And)
                return GroupOperator.And(co, fo);
            go.Operands.Add(fo);
            return go;
        }
        protected FunctionOperator FindAndRemoveCustomOperator(ref CriteriaOperator co, string fieldName) {
            var fo = co as FunctionOperator;
            if (IsValidFuncOperator(fo, fieldName)) {
                co = null;
                return fo;
            }
            var go = co as GroupOperator;
            if (ReferenceEquals(go, null))
                return null;
            fo = go.Operands.FirstOrDefault(op => IsValidFuncOperator(op as FunctionOperator, fieldName)) as FunctionOperator;
            if (ReferenceEquals(fo, null))
                return null;
            go.Operands.Remove(fo);
            return fo;
        }
        protected bool IsValidFuncOperator(FunctionOperator fo, string fieldName) {
            if (ReferenceEquals(fo, null) || fo.OperatorType != FunctionOperatorType.Custom || fo.Operands.Count != 3)
                return false;

            var customNameOp = fo.Operands[0] as OperandValue;
            if (ReferenceEquals(customNameOp, null) || customNameOp.Value.ToString() != AccentInsensitiveFilterStatic.Name)
                return false;

            var oProp = fo.Operands[2] as OperandProperty;
            if (oProp.PropertyName != fieldName)
                return false;
            return true;
        }
    }
}
