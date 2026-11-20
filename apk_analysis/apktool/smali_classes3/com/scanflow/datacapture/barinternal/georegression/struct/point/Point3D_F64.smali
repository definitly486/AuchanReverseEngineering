.class public Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;
.super Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;
.source "Point3D_F64.java"


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 37
    invoke-direct {p0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;-><init>()V

    return-void
.end method


# virtual methods
.method public setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point3D_F64;
    .locals 0

    .line 50
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->_setTo(Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;)V

    return-object p0
.end method

.method public toString()Ljava/lang/String;
    .locals 1

    .line 61
    const-string v0, "P"

    invoke-virtual {p0, v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/GeoTuple3D_F64;->toString(Ljava/lang/String;)Ljava/lang/String;

    move-result-object v0

    return-object v0
.end method
