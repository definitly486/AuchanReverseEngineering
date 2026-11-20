.class public final Landroidx/collection/LongLongMapKt;
.super Ljava/lang/Object;
.source "LongLongMap.kt"


# static fields
.field private static final EmptyLongLongMap:Landroidx/collection/MutableLongLongMap;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 43
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Landroidx/collection/MutableLongLongMap;-><init>(I)V

    sput-object v0, Landroidx/collection/LongLongMapKt;->EmptyLongLongMap:Landroidx/collection/MutableLongLongMap;

    return-void
.end method

.method public static final buildLongLongMap(ILkotlin/jvm/functions/Function1;)Landroidx/collection/LongLongMap;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableLongLongMap;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/LongLongMap;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 247
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    invoke-direct {v0, p0}, Landroidx/collection/MutableLongLongMap;-><init>(I)V

    invoke-interface {p1, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final buildLongLongMap(Lkotlin/jvm/functions/Function1;)Landroidx/collection/LongLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableLongLongMap;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/LongLongMap;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 230
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-interface {p0, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final emptyLongLongMap()Landroidx/collection/LongLongMap;
    .locals 1

    .line 46
    sget-object v0, Landroidx/collection/LongLongMapKt;->EmptyLongLongMap:Landroidx/collection/MutableLongLongMap;

    return-object v0
.end method

.method public static final longLongMapOf()Landroidx/collection/LongLongMap;
    .locals 1

    .line 49
    sget-object v0, Landroidx/collection/LongLongMapKt;->EmptyLongLongMap:Landroidx/collection/MutableLongLongMap;

    return-object v0
.end method

.method public static final longLongMapOf(JJ)Landroidx/collection/LongLongMap;
    .locals 4

    .line 53
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    return-object v0
.end method

.method public static final longLongMapOf(JJJJ)Landroidx/collection/LongLongMap;
    .locals 4

    .line 65
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 66
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 67
    invoke-virtual {v0, p4, p5, p6, p7}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    return-object v0
.end method

.method public static final longLongMapOf(JJJJJJ)Landroidx/collection/LongLongMap;
    .locals 4

    .line 82
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 83
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 84
    invoke-virtual {v0, p4, p5, p6, p7}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 85
    invoke-virtual {v0, p8, p9, p10, p11}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    return-object v0
.end method

.method public static final longLongMapOf(JJJJJJJJ)Landroidx/collection/LongLongMap;
    .locals 4

    .line 102
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 103
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 104
    invoke-virtual {v0, p4, p5, p6, p7}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 105
    invoke-virtual {v0, p8, p9, p10, p11}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    move-wide/from16 p0, p12

    move-wide/from16 p2, p14

    .line 106
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    return-object v0
.end method

.method public static final longLongMapOf(JJJJJJJJJJ)Landroidx/collection/LongLongMap;
    .locals 4

    .line 125
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 126
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 127
    invoke-virtual {v0, p4, p5, p6, p7}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 128
    invoke-virtual {v0, p8, p9, p10, p11}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    move-wide/from16 p0, p12

    move-wide/from16 p2, p14

    .line 129
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    move-wide/from16 p0, p16

    move-wide/from16 p2, p18

    .line 130
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    return-object v0
.end method

.method public static final mutableLongLongMapOf()Landroidx/collection/MutableLongLongMap;
    .locals 4

    .line 134
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public static final mutableLongLongMapOf(JJ)Landroidx/collection/MutableLongLongMap;
    .locals 4

    .line 138
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    return-object v0
.end method

.method public static final mutableLongLongMapOf(JJJJ)Landroidx/collection/MutableLongLongMap;
    .locals 4

    .line 150
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 151
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 152
    invoke-virtual {v0, p4, p5, p6, p7}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    return-object v0
.end method

.method public static final mutableLongLongMapOf(JJJJJJ)Landroidx/collection/MutableLongLongMap;
    .locals 4

    .line 167
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 168
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 169
    invoke-virtual {v0, p4, p5, p6, p7}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 170
    invoke-virtual {v0, p8, p9, p10, p11}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    return-object v0
.end method

.method public static final mutableLongLongMapOf(JJJJJJJJ)Landroidx/collection/MutableLongLongMap;
    .locals 4

    .line 187
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 188
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 189
    invoke-virtual {v0, p4, p5, p6, p7}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 190
    invoke-virtual {v0, p8, p9, p10, p11}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    move-wide/from16 p0, p12

    move-wide/from16 p2, p14

    .line 191
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    return-object v0
.end method

.method public static final mutableLongLongMapOf(JJJJJJJJJJ)Landroidx/collection/MutableLongLongMap;
    .locals 4

    .line 210
    new-instance v0, Landroidx/collection/MutableLongLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableLongLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 211
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 212
    invoke-virtual {v0, p4, p5, p6, p7}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    .line 213
    invoke-virtual {v0, p8, p9, p10, p11}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    move-wide/from16 p0, p12

    move-wide/from16 p2, p14

    .line 214
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    move-wide/from16 p0, p16

    move-wide/from16 p2, p18

    .line 215
    invoke-virtual {v0, p0, p1, p2, p3}, Landroidx/collection/MutableLongLongMap;->set(JJ)V

    return-object v0
.end method
