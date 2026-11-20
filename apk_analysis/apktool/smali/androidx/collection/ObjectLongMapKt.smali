.class public final Landroidx/collection/ObjectLongMapKt;
.super Ljava/lang/Object;
.source "ObjectLongMap.kt"


# static fields
.field private static final EmptyObjectLongMap:Landroidx/collection/MutableObjectLongMap;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 44
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Landroidx/collection/MutableObjectLongMap;-><init>(I)V

    sput-object v0, Landroidx/collection/ObjectLongMapKt;->EmptyObjectLongMap:Landroidx/collection/MutableObjectLongMap;

    return-void
.end method

.method public static final buildObjectLongMap(ILkotlin/jvm/functions/Function1;)Landroidx/collection/ObjectLongMap;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(I",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableObjectLongMap<",
            "TK;>;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/ObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 254
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    invoke-direct {v0, p0}, Landroidx/collection/MutableObjectLongMap;-><init>(I)V

    invoke-interface {p1, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final buildObjectLongMap(Lkotlin/jvm/functions/Function1;)Landroidx/collection/ObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableObjectLongMap<",
            "TK;>;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/ObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 236
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-interface {p0, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final emptyObjectLongMap()Landroidx/collection/ObjectLongMap;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">()",
            "Landroidx/collection/ObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 48
    sget-object v0, Landroidx/collection/ObjectLongMapKt;->EmptyObjectLongMap:Landroidx/collection/MutableObjectLongMap;

    const-string v1, "null cannot be cast to non-null type androidx.collection.ObjectLongMap<K of androidx.collection.ObjectLongMapKt.emptyObjectLongMap>"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    return-object v0
.end method

.method public static final mutableObjectLongMapOf()Landroidx/collection/MutableObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">()",
            "Landroidx/collection/MutableObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 137
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public static final mutableObjectLongMapOf(Ljava/lang/Object;J)Landroidx/collection/MutableObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(TK;J)",
            "Landroidx/collection/MutableObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 143
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    return-object v0
.end method

.method public static final mutableObjectLongMapOf(Ljava/lang/Object;JLjava/lang/Object;J)Landroidx/collection/MutableObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(TK;JTK;J)",
            "Landroidx/collection/MutableObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 155
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 156
    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 157
    invoke-virtual {v0, p3, p4, p5}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    return-object v0
.end method

.method public static final mutableObjectLongMapOf(Ljava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;J)Landroidx/collection/MutableObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(TK;JTK;JTK;J)",
            "Landroidx/collection/MutableObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 172
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 173
    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 174
    invoke-virtual {v0, p3, p4, p5}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 175
    invoke-virtual {v0, p6, p7, p8}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    return-object v0
.end method

.method public static final mutableObjectLongMapOf(Ljava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;J)Landroidx/collection/MutableObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(TK;JTK;JTK;JTK;J)",
            "Landroidx/collection/MutableObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 192
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 193
    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 194
    invoke-virtual {v0, p3, p4, p5}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 195
    invoke-virtual {v0, p6, p7, p8}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 196
    invoke-virtual {v0, p9, p10, p11}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    return-object v0
.end method

.method public static final mutableObjectLongMapOf(Ljava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;J)Landroidx/collection/MutableObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(TK;JTK;JTK;JTK;JTK;J)",
            "Landroidx/collection/MutableObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 215
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 216
    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 217
    invoke-virtual {v0, p3, p4, p5}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 218
    invoke-virtual {v0, p6, p7, p8}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 219
    invoke-virtual {v0, p9, p10, p11}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    move-object/from16 p0, p12

    move-wide/from16 p1, p13

    .line 220
    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    return-object v0
.end method

.method public static final objectLongMap()Landroidx/collection/ObjectLongMap;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">()",
            "Landroidx/collection/ObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 52
    sget-object v0, Landroidx/collection/ObjectLongMapKt;->EmptyObjectLongMap:Landroidx/collection/MutableObjectLongMap;

    const-string v1, "null cannot be cast to non-null type androidx.collection.ObjectLongMap<K of androidx.collection.ObjectLongMapKt.objectLongMap>"

    invoke-static {v0, v1}, Lkotlin/jvm/internal/Intrinsics;->checkNotNull(Ljava/lang/Object;Ljava/lang/String;)V

    return-object v0
.end method

.method public static final objectLongMapOf(Ljava/lang/Object;J)Landroidx/collection/ObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(TK;J)",
            "Landroidx/collection/ObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 56
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    return-object v0
.end method

.method public static final objectLongMapOf(Ljava/lang/Object;JLjava/lang/Object;J)Landroidx/collection/ObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(TK;JTK;J)",
            "Landroidx/collection/ObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 68
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 69
    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 70
    invoke-virtual {v0, p3, p4, p5}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    return-object v0
.end method

.method public static final objectLongMapOf(Ljava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;J)Landroidx/collection/ObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(TK;JTK;JTK;J)",
            "Landroidx/collection/ObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 85
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 86
    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 87
    invoke-virtual {v0, p3, p4, p5}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 88
    invoke-virtual {v0, p6, p7, p8}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    return-object v0
.end method

.method public static final objectLongMapOf(Ljava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;J)Landroidx/collection/ObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(TK;JTK;JTK;JTK;J)",
            "Landroidx/collection/ObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 105
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 106
    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 107
    invoke-virtual {v0, p3, p4, p5}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 108
    invoke-virtual {v0, p6, p7, p8}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 109
    invoke-virtual {v0, p9, p10, p11}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    return-object v0
.end method

.method public static final objectLongMapOf(Ljava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;JLjava/lang/Object;J)Landroidx/collection/ObjectLongMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "<K:",
            "Ljava/lang/Object;",
            ">(TK;JTK;JTK;JTK;JTK;J)",
            "Landroidx/collection/ObjectLongMap<",
            "TK;>;"
        }
    .end annotation

    .line 128
    new-instance v0, Landroidx/collection/MutableObjectLongMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableObjectLongMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 129
    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 130
    invoke-virtual {v0, p3, p4, p5}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 131
    invoke-virtual {v0, p6, p7, p8}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    .line 132
    invoke-virtual {v0, p9, p10, p11}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    move-object/from16 p0, p12

    move-wide/from16 p1, p13

    .line 133
    invoke-virtual {v0, p0, p1, p2}, Landroidx/collection/MutableObjectLongMap;->set(Ljava/lang/Object;J)V

    return-object v0
.end method
