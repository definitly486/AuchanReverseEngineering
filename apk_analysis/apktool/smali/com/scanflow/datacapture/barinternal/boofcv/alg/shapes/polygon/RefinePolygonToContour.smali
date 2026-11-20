.class public Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;
.super Ljava/lang/Object;
.source "RefinePolygonToContour.java"


# instance fields
.field private final lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

.field private final polar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

.field private final work:Ljava/util/List;


# direct methods
.method public constructor <init>()V
    .locals 2

    .line 40
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 42
    new-instance v0, Ljava/util/ArrayList;

    invoke-direct {v0}, Ljava/util/ArrayList;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->work:Ljava/util/List;

    .line 43
    new-instance v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;-><init>()V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->polar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    .line 45
    new-instance v0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    new-instance v1, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour$$ExternalSyntheticLambda0;

    invoke-direct {v1}, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour$$ExternalSyntheticLambda0;-><init>()V

    invoke-direct {v0, v1}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;-><init>(Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/Factory;)V

    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    return-void
.end method


# virtual methods
.method public process(Ljava/util/List;Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;)V
    .locals 10

    .line 57
    iget v0, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    const/4 v1, 0x1

    sub-int/2addr v0, v1

    const/4 v2, 0x0

    move v3, v0

    move v0, v2

    move v4, v0

    :goto_0
    iget v5, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-ge v0, v5, :cond_1

    .line 58
    invoke-virtual {p2, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v3

    invoke-virtual {p2, v0}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v5

    if-le v3, v5, :cond_0

    add-int/lit8 v4, v4, 0x1

    :cond_0
    add-int/lit8 v3, v0, 0x1

    move v9, v3

    move v3, v0

    move v0, v9

    goto :goto_0

    :cond_1
    if-le v4, v1, :cond_2

    move v0, v1

    goto :goto_1

    :cond_2
    move v0, v2

    .line 64
    :goto_1
    iget-object v3, p3, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->vertexes:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v3, v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 65
    iget-object v3, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    iget v4, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    invoke-virtual {v3, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;->resize(I)Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    .line 68
    iget v3, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    sub-int/2addr v3, v1

    move v4, v3

    move v3, v2

    :goto_2
    iget v5, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-ge v3, v5, :cond_7

    .line 69
    invoke-virtual {p2, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v5

    .line 70
    invoke-virtual {p2, v3}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->get(I)I

    move-result v6

    if-eqz v0, :cond_3

    move v9, v6

    move v6, v5

    move v5, v9

    :cond_3
    if-le v5, v6, :cond_6

    .line 80
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->work:Ljava/util/List;

    invoke-interface {v7}, Ljava/util/List;->clear()V

    .line 81
    :goto_3
    invoke-interface {p1}, Ljava/util/List;->size()I

    move-result v7

    if-ge v5, v7, :cond_4

    .line 82
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->work:Ljava/util/List;

    invoke-interface {p1, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-interface {v7, v8}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v5, v5, 0x1

    goto :goto_3

    :cond_4
    move v5, v2

    :goto_4
    if-ge v5, v6, :cond_5

    .line 85
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->work:Ljava/util/List;

    invoke-interface {p1, v5}, Ljava/util/List;->get(I)Ljava/lang/Object;

    move-result-object v8

    check-cast v8, Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_I32;

    invoke-interface {v7, v8}, Ljava/util/List;->add(Ljava/lang/Object;)Z

    add-int/lit8 v5, v5, 0x1

    goto :goto_4

    .line 87
    :cond_5
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->work:Ljava/util/List;

    invoke-interface {v5}, Ljava/util/List;->size()I

    move-result v6

    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->polar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-static {v5, v2, v6, v7}, Lcom/scanflow/datacapture/barinternal/georegression/fitting/line/FitLine_I32;->polar(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    goto :goto_5

    :cond_6
    sub-int/2addr v6, v5

    .line 89
    iget-object v7, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->polar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    invoke-static {p1, v5, v6, v7}, Lcom/scanflow/datacapture/barinternal/georegression/fitting/line/FitLine_I32;->polar(Ljava/util/List;IILcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    .line 92
    :goto_5
    iget-object v5, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->polar:Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;

    iget-object v6, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v6, v4}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v4

    check-cast v4, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    invoke-static {v5, v4}, Lcom/scanflow/datacapture/barinternal/georegression/geometry/UtilLine2D_F64;->convert(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LinePolar2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    add-int/lit8 v4, v3, 0x1

    move v9, v4

    move v4, v3

    move v3, v9

    goto :goto_2

    :cond_7
    sub-int/2addr v5, v1

    .line 96
    :goto_6
    iget p1, p2, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray_I32;->size:I

    if-ge v2, p1, :cond_8

    .line 97
    iget-object p1, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {p1, v5}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object p1

    check-cast p1, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 98
    iget-object v0, p0, Lcom/scanflow/datacapture/barinternal/boofcv/alg/shapes/polygon/RefinePolygonToContour;->lines:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogArray;

    invoke-virtual {v0, v2}, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/FastAccess;->get(I)Ljava/lang/Object;

    move-result-object v0

    check-cast v0, Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;

    .line 100
    invoke-virtual {p3, v2}, Lcom/scanflow/datacapture/barinternal/georegression/struct/shapes/Polygon2D_F64;->get(I)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    move-result-object v1

    invoke-static {p1, v0, v1}, Lcom/scanflow/datacapture/barinternal/georegression/metric/Intersection2D_F64;->intersection(Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/line/LineGeneral2D_F64;Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;)Lcom/scanflow/datacapture/barinternal/georegression/struct/point/Point2D_F64;

    add-int/lit8 p1, v2, 0x1

    move v5, v2

    move v2, p1

    goto :goto_6

    :cond_8
    return-void
.end method
