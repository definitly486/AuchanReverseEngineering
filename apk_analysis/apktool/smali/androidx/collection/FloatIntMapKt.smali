.class public final Landroidx/collection/FloatIntMapKt;
.super Ljava/lang/Object;
.source "FloatIntMap.kt"


# static fields
.field private static final EmptyFloatIntMap:Landroidx/collection/MutableFloatIntMap;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 43
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatIntMap;-><init>(I)V

    sput-object v0, Landroidx/collection/FloatIntMapKt;->EmptyFloatIntMap:Landroidx/collection/MutableFloatIntMap;

    return-void
.end method

.method public static final buildFloatIntMap(ILkotlin/jvm/functions/Function1;)Landroidx/collection/FloatIntMap;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableFloatIntMap;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/FloatIntMap;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 247
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    invoke-direct {v0, p0}, Landroidx/collection/MutableFloatIntMap;-><init>(I)V

    invoke-interface {p1, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final buildFloatIntMap(Lkotlin/jvm/functions/Function1;)Landroidx/collection/FloatIntMap;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableFloatIntMap;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/FloatIntMap;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 230
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-interface {p0, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final emptyFloatIntMap()Landroidx/collection/FloatIntMap;
    .locals 1

    .line 46
    sget-object v0, Landroidx/collection/FloatIntMapKt;->EmptyFloatIntMap:Landroidx/collection/MutableFloatIntMap;

    return-object v0
.end method

.method public static final floatIntMapOf()Landroidx/collection/FloatIntMap;
    .locals 1

    .line 49
    sget-object v0, Landroidx/collection/FloatIntMapKt;->EmptyFloatIntMap:Landroidx/collection/MutableFloatIntMap;

    return-object v0
.end method

.method public static final floatIntMapOf(FI)Landroidx/collection/FloatIntMap;
    .locals 4

    .line 53
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-object v0
.end method

.method public static final floatIntMapOf(FIFI)Landroidx/collection/FloatIntMap;
    .locals 4

    .line 65
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 66
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 67
    invoke-virtual {v0, p2, p3}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-object v0
.end method

.method public static final floatIntMapOf(FIFIFI)Landroidx/collection/FloatIntMap;
    .locals 4

    .line 82
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 83
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 84
    invoke-virtual {v0, p2, p3}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 85
    invoke-virtual {v0, p4, p5}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-object v0
.end method

.method public static final floatIntMapOf(FIFIFIFI)Landroidx/collection/FloatIntMap;
    .locals 4

    .line 102
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 103
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 104
    invoke-virtual {v0, p2, p3}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 105
    invoke-virtual {v0, p4, p5}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 106
    invoke-virtual {v0, p6, p7}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-object v0
.end method

.method public static final floatIntMapOf(FIFIFIFIFI)Landroidx/collection/FloatIntMap;
    .locals 4

    .line 125
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 126
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 127
    invoke-virtual {v0, p2, p3}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 128
    invoke-virtual {v0, p4, p5}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 129
    invoke-virtual {v0, p6, p7}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 130
    invoke-virtual {v0, p8, p9}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-object v0
.end method

.method public static final mutableFloatIntMapOf()Landroidx/collection/MutableFloatIntMap;
    .locals 4

    .line 134
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public static final mutableFloatIntMapOf(FI)Landroidx/collection/MutableFloatIntMap;
    .locals 4

    .line 138
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-object v0
.end method

.method public static final mutableFloatIntMapOf(FIFI)Landroidx/collection/MutableFloatIntMap;
    .locals 4

    .line 150
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 151
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 152
    invoke-virtual {v0, p2, p3}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-object v0
.end method

.method public static final mutableFloatIntMapOf(FIFIFI)Landroidx/collection/MutableFloatIntMap;
    .locals 4

    .line 167
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 168
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 169
    invoke-virtual {v0, p2, p3}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 170
    invoke-virtual {v0, p4, p5}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-object v0
.end method

.method public static final mutableFloatIntMapOf(FIFIFIFI)Landroidx/collection/MutableFloatIntMap;
    .locals 4

    .line 187
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 188
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 189
    invoke-virtual {v0, p2, p3}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 190
    invoke-virtual {v0, p4, p5}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 191
    invoke-virtual {v0, p6, p7}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-object v0
.end method

.method public static final mutableFloatIntMapOf(FIFIFIFIFI)Landroidx/collection/MutableFloatIntMap;
    .locals 4

    .line 210
    new-instance v0, Landroidx/collection/MutableFloatIntMap;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatIntMap;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    .line 211
    invoke-virtual {v0, p0, p1}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 212
    invoke-virtual {v0, p2, p3}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 213
    invoke-virtual {v0, p4, p5}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 214
    invoke-virtual {v0, p6, p7}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    .line 215
    invoke-virtual {v0, p8, p9}, Landroidx/collection/MutableFloatIntMap;->set(FI)V

    return-object v0
.end method
