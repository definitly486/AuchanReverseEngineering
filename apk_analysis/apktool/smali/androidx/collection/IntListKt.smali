.class public final Landroidx/collection/IntListKt;
.super Ljava/lang/Object;
.source "IntList.kt"


# static fields
.field private static final EmptyIntList:Landroidx/collection/IntList;


# direct methods
.method static constructor <clinit>()V
    .locals 2

    .line 879
    new-instance v0, Landroidx/collection/MutableIntList;

    const/4 v1, 0x0

    invoke-direct {v0, v1}, Landroidx/collection/MutableIntList;-><init>(I)V

    sput-object v0, Landroidx/collection/IntListKt;->EmptyIntList:Landroidx/collection/IntList;

    return-void
.end method

.method public static final buildIntList(ILkotlin/jvm/functions/Function1;)Landroidx/collection/IntList;
    .locals 1
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableIntList;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/IntList;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 966
    new-instance v0, Landroidx/collection/MutableIntList;

    invoke-direct {v0, p0}, Landroidx/collection/MutableIntList;-><init>(I)V

    invoke-interface {p1, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final buildIntList(Lkotlin/jvm/functions/Function1;)Landroidx/collection/IntList;
    .locals 4
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lkotlin/jvm/functions/Function1<",
            "-",
            "Landroidx/collection/MutableIntList;",
            "Lcom/scanflow/datacapture/barinternal/kotlin/Unit;",
            ">;)",
            "Landroidx/collection/IntList;"
        }
    .end annotation

    const-string v0, "builderAction"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 949
    new-instance v0, Landroidx/collection/MutableIntList;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableIntList;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    invoke-interface {p0, v0}, Lkotlin/jvm/functions/Function1;->invoke(Ljava/lang/Object;)Ljava/lang/Object;

    return-object v0
.end method

.method public static final emptyIntList()Landroidx/collection/IntList;
    .locals 1

    .line 882
    sget-object v0, Landroidx/collection/IntListKt;->EmptyIntList:Landroidx/collection/IntList;

    return-object v0
.end method

.method public static final intListOf()Landroidx/collection/IntList;
    .locals 1

    .line 885
    sget-object v0, Landroidx/collection/IntListKt;->EmptyIntList:Landroidx/collection/IntList;

    return-object v0
.end method

.method public static final intListOf(I)Landroidx/collection/IntList;
    .locals 0

    .line 888
    invoke-static {p0}, Landroidx/collection/IntListKt;->mutableIntListOf(I)Landroidx/collection/MutableIntList;

    move-result-object p0

    return-object p0
.end method

.method public static final intListOf(II)Landroidx/collection/IntList;
    .locals 0

    .line 891
    invoke-static {p0, p1}, Landroidx/collection/IntListKt;->mutableIntListOf(II)Landroidx/collection/MutableIntList;

    move-result-object p0

    return-object p0
.end method

.method public static final intListOf(III)Landroidx/collection/IntList;
    .locals 0

    .line 898
    invoke-static {p0, p1, p2}, Landroidx/collection/IntListKt;->mutableIntListOf(III)Landroidx/collection/MutableIntList;

    move-result-object p0

    return-object p0
.end method

.method public static final varargs intListOf([I)Landroidx/collection/IntList;
    .locals 2

    const-string v0, "elements"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 902
    new-instance v0, Landroidx/collection/MutableIntList;

    array-length v1, p0

    invoke-direct {v0, v1}, Landroidx/collection/MutableIntList;-><init>(I)V

    .line 672
    iget v1, v0, Landroidx/collection/IntList;->_size:I

    invoke-virtual {v0, v1, p0}, Landroidx/collection/MutableIntList;->addAll(I[I)Z

    return-object v0
.end method

.method public static final mutableIntListOf()Landroidx/collection/MutableIntList;
    .locals 4

    .line 905
    new-instance v0, Landroidx/collection/MutableIntList;

    const/4 v1, 0x1

    const/4 v2, 0x0

    const/4 v3, 0x0

    invoke-direct {v0, v3, v1, v2}, Landroidx/collection/MutableIntList;-><init>(IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-object v0
.end method

.method public static final mutableIntListOf(I)Landroidx/collection/MutableIntList;
    .locals 2

    .line 909
    new-instance v0, Landroidx/collection/MutableIntList;

    const/4 v1, 0x1

    invoke-direct {v0, v1}, Landroidx/collection/MutableIntList;-><init>(I)V

    .line 712
    invoke-virtual {v0, p0}, Landroidx/collection/MutableIntList;->add(I)Z

    return-object v0
.end method

.method public static final mutableIntListOf(II)Landroidx/collection/MutableIntList;
    .locals 2

    .line 916
    new-instance v0, Landroidx/collection/MutableIntList;

    const/4 v1, 0x2

    invoke-direct {v0, v1}, Landroidx/collection/MutableIntList;-><init>(I)V

    .line 712
    invoke-virtual {v0, p0}, Landroidx/collection/MutableIntList;->add(I)Z

    .line 712
    invoke-virtual {v0, p1}, Landroidx/collection/MutableIntList;->add(I)Z

    return-object v0
.end method

.method public static final mutableIntListOf(III)Landroidx/collection/MutableIntList;
    .locals 2

    .line 926
    new-instance v0, Landroidx/collection/MutableIntList;

    const/4 v1, 0x3

    invoke-direct {v0, v1}, Landroidx/collection/MutableIntList;-><init>(I)V

    .line 712
    invoke-virtual {v0, p0}, Landroidx/collection/MutableIntList;->add(I)Z

    .line 712
    invoke-virtual {v0, p1}, Landroidx/collection/MutableIntList;->add(I)Z

    .line 712
    invoke-virtual {v0, p2}, Landroidx/collection/MutableIntList;->add(I)Z

    return-object v0
.end method

.method public static final varargs mutableIntListOf([I)Landroidx/collection/MutableIntList;
    .locals 2

    const-string v0, "elements"

    invoke-static {p0, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    .line 935
    new-instance v0, Landroidx/collection/MutableIntList;

    array-length v1, p0

    invoke-direct {v0, v1}, Landroidx/collection/MutableIntList;-><init>(I)V

    .line 672
    iget v1, v0, Landroidx/collection/IntList;->_size:I

    invoke-virtual {v0, v1, p0}, Landroidx/collection/MutableIntList;->addAll(I[I)Z

    return-object v0
.end method
