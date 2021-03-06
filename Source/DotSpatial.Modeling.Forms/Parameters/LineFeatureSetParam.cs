﻿// ********************************************************************************************************
// Product Name: DotSpatial.Tools.LineFeatureSetParam
// Description:  Parameters past back from a ITool to the toolbox manager
//
// ********************************************************************************************************
//
// The Original Code is Toolbox.dll for the DotSpatial 4.6/6 ToolManager project
//
// The Initial Developer of this Original Code is Brian Marchionni. Created in Oct, 2008.
//
// Contributor(s): (Open source contributors should list themselves and their modifications here).
//
// ********************************************************************************************************

using System.Collections.Generic;
using System.IO;
using DotSpatial.Data;
using DotSpatial.Modeling.Forms.Elements;

namespace DotSpatial.Modeling.Forms.Parameters
{
    /// <summary>
    /// Line Feature Parameter past back from a ITool to the toolbox manager
    /// </summary>
    public class LineFeatureSetParam : Parameter
    {
        /// <summary>
        /// Creates a new Line Feature Set parameter
        /// </summary>
        /// <param name="name">The name of the parameter</param>
        public LineFeatureSetParam(string name)
        {
            Name = name;
            Value = new FeatureSet();
            ParamVisible = ShowParamInModel.Always;
            ParamType = "DotSpatial LineFeatureSet Param";
            DefaultSpecified = false;
        }

        /// <summary>
        /// Specifies the value of the parameter (This is also the default value for input)
        /// </summary>
        public new IFeatureSet Value
        {
            get { return (IFeatureSet)base.Value; }
            set
            {
                base.Value = value;
                DefaultSpecified = true;
            }
        }

        /// <summary>
        /// Generates a default instance of the data type so that tools have something to write too
        /// </summary>
        /// <param name="path"></param>
        public override void GenerateDefaultOutput(string path)
        {
            FeatureSet addedFeatureSet = new LineShapefile
                                             {
                                                 Filename =
                                                     Path.GetDirectoryName(path) +
                                                     Path.DirectorySeparatorChar + ModelName + ".shp"
                                             };
            Value = addedFeatureSet;
        }

        /// <summary>
        /// This method returns the dialog component that should be used to visualise INPUT to this parameter
        /// </summary>
        /// <param name="dataSets"></param>
        /// <returns></returns>
        public override DialogElement InputDialogElement(List<DataSetArray> dataSets)
        {
            return (new LineElement(this, dataSets));
        }

        /// <summary>
        /// This method returns the dialog component that should be used to visualise OUTPUT to this parameter
        /// </summary>
        /// <param name="dataSets"></param>
        /// <returns></returns>
        public override DialogElement OutputDialogElement(List<DataSetArray> dataSets)
        {
            return (new LineElementOut(this, dataSets));
        }
    }
}