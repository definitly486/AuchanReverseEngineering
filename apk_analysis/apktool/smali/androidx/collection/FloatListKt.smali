.class public final Landroidx/collection/FloatListKt;
.super Ljava/lang/Object;
.source "FloatList.kt"


# static fields
.field private static final EmptyFloatList:Landroidx/collection/FloatList;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 885
    new-instance v0, Landroidx/collection/MutableFloatList;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatList;-><init>(I)V

    sput-object v0, Landroidx/collection/FloatListKt;->EmptyFloatList:Landroidx/collection/FloatList;

    return-void
.end method

.method public static final buildFloatList(ILkotlin/jvm/functions/Function1;)Landroidx/collection/FloatList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableFloatList;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/FloatList;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 974
    new-instance v0, Landroidx/collection/MutableFloatList;

    invoke-direct {v0, p0}, Landroidx/collection/MutableFloatList;-><init>(I)V

    invoke-interface {p1, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final buildFloatList(Lkotlin/jvm/functions/Function1;)Landroidx/collection/FloatList;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableFloatList;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/FloatList;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 957
    new-instance v0, Landroidx/collection/MutableFloatList;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatList;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-interface {p0, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final emptyFloatList()Landroidx/collection/FloatList;
    .locals 1

    .line 888
    sget-object v0, Landroidx/collection/FloatListKt;->EmptyFloatList:Landroidx/collection/FloatList;

    return-object v0
.end method

.method public static final floatListOf()Landroidx/collection/FloatList;
    .locals 1

    .line 891
    sget-object v0, Landroidx/collection/FloatListKt;->EmptyFloatList:Landroidx/collection/FloatList;

    return-object v0
.end method

.method public static final floatListOf(F)Landroidx/collection/FloatList;
    .locals 0

    .line 894
    invoke-static {p0}, Landroidx/collection/FloatListKt;->mutableFloatListOf(F)Landroidx/collection/MutableFloatList;

    move-result-object p0

    return-object p0
.end method

.method public static final floatListOf(FF)Landroidx/collection/FloatList;
    .locals 0

    .line 898
    invoke-static {p0, p1}, Landroidx/collection/FloatListKt;->mutableFloatListOf(FF)Landroidx/collection/MutableFloatList;

    move-result-object p0

    return-object p0
.end method

.method public static final floatListOf(FFF)Landroidx/collection/FloatList;
    .locals 0

    .line 905
    invoke-static {p0, p1, p2}, Landroidx/collection/FloatListKt;->mutableFloatListOf(FFF)Landroidx/collection/MutableFloatList;

    move-result-object p0

    return-object p0
.end method

.method public static final varargs floatListOf([F)Landroidx/collection/FloatList;
    .locals 2

    const-string v0, "elements"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 909
    new-instance v0, Landroidx/collection/MutableFloatList;

    array-length v1, p0

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatList;-><init>(I)V

    .line 675
    iget v1, v0, Landroidx/collection/FloatList;->_size:I

    invoke-virtual {v0, v1, p0}, Landroidx/collection/MutableFloatList;->addAll(I[F)Z

    return-object v0
.end method

.method public static final mutableFloatListOf()Landroidx/collection/MutableFloatList;
    .locals 4

    .line 912
    new-instance v0, Landroidx/collection/MutableFloatList;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableFloatList;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public static final mutableFloatListOf(F)Landroidx/collection/MutableFloatList;
    .locals 2

    .line 916
    new-instance v0, Landroidx/collection/MutableFloatList;

    const/4 v1, 0x1

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatList;-><init>(I)V

    .line 715
    invoke-virtual {v0, p0}, Landroidx/collection/MutableFloatList;->add(F)Z

    return-object v0
.end method

.method public static final mutableFloatListOf(FF)Landroidx/collection/MutableFloatList;
    .locals 2

    .line 923
    new-instance v0, Landroidx/collection/MutableFloatList;

    const/4 v1, 0x2

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatList;-><init>(I)V

    .line 715
    invoke-virtual {v0, p0}, Landroidx/collection/MutableFloatList;->add(F)Z

    .line 715
    invoke-virtual {v0, p1}, Landroidx/collection/MutableFloatList;->add(F)Z

    return-object v0
.end method

.method public static final mutableFloatListOf(FFF)Landroidx/collection/MutableFloatList;
    .locals 2

    .line 934
    new-instance v0, Landroidx/collection/MutableFloatList;

    const/4 v1, 0x3

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatList;-><init>(I)V

    .line 715
    invoke-virtual {v0, p0}, Landroidx/collection/MutableFloatList;->add(F)Z

    .line 715
    invoke-virtual {v0, p1}, Landroidx/collection/MutableFloatList;->add(F)Z

    .line 715
    invoke-virtual {v0, p2}, Landroidx/collection/MutableFloatList;->add(F)Z

    return-object v0
.end method

.method public static final varargs mutableFloatListOf([F)Landroidx/collection/MutableFloatList;
    .locals 2

    const-string v0, "elements"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 943
    new-instance v0, Landroidx/collection/MutableFloatList;

    array-length v1, p0

    invoke-direct {v0, v1}, Landroidx/collection/MutableFloatList;-><init>(I)V

    .line 675
    iget v1, v0, Landroidx/collection/FloatList;->_size:I

    invoke-virtual {v0, v1, p0}, Landroidx/collection/MutableFloatList;->addAll(I[F)Z

    return-object v0
.end method
