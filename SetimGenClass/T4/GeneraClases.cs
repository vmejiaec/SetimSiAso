
namespace SetimModelo
{
    /// <summary>
    /// Poco class para asoPeriodo
    /// </summary>
    partial class asoPeriodo
    {
    // Es PK? True
    public System.Int32         Id                  { get; set; }
    // Es PK? False
    public System.Int32         No_Periodo          { get; set; }
    // Es PK? False
    public System.DateTime      Fecha_Periodo       { get; set; }
    // Es PK? False
    public System.String        Estado              { get; set; }
    // Es PK? False
    public System.String        Descripcion         { get; set; }
    } 
}


//sp_asoPeriodo_5GenerarPeriodos        
// --@p_No_Periodos_a_Generar : System.Int32 es Output? False 

//sp_asoPeriodo_4Del        
// --@Id : System.Int32 es Output? False 

//sp_asoPeriodo_2Ins        
// --@No_Periodo : System.Int32 es Output? False 
// --@Fecha_Periodo : System.DateTime es Output? False 
// --@Estado : System.String es Output? False 
// --@Descripcion : System.String es Output? False 
// --@InsertedId : System.Int32 es Output? True 

//sp_asoPeriodo_1Sel        

//sp_asoPeriodo_1SelById        
// --@Id : System.Int32 es Output? False 

//sp_asoPeriodo_3Upd        
// --@Id : System.Int32 es Output? False 
// --@No_Periodo : System.Int32 es Output? False 
// --@Fecha_Periodo : System.DateTime es Output? False 
// --@Estado : System.String es Output? False 
// --@Descripcion : System.String es Output? False 

//sp_asoPeriodo_1SelByAll        
// --@No_Periodo : System.Int32 es Output? False 
// --@Fecha_Periodo : System.DateTime es Output? False 
// --@Estado : System.String es Output? False 
// --@Descripcion : System.String es Output? False 
// --@PageIndex : System.Int32 es Output? False 
// --@PageSize : System.Int32 es Output? False 
// --@SortField : System.String es Output? False 
// --@SortDirection : System.String es Output? False 


