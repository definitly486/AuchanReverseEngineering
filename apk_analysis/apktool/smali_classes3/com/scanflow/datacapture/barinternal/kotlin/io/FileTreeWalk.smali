.class public final Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;
.super Ljava/lang/Object;
.source "FileTreeWalk.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;


# annotations
.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$DirectoryState;,
        Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator;,
        Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$WalkState;
    }
.end annotation


# instance fields
.field private final direction:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

.field private final maxDepth:I

.field private final onEnter:Lkotlin/jvm/functions/Function1;

.field private final onFail:Lkotlin/jvm/functions/Function2;

.field private final onLeave:Lkotlin/jvm/functions/Function1;

.field private final start:Ljava/io/File;


# direct methods
.method public constructor <init>(Ljava/io/File;Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;)V
    .locals 10

    const-string v0, "start"

    invoke-static {p1, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const-string v0, "direction"

    invoke-static {p2, v0}, Lkotlin/jvm/internal/Intrinsics;->checkNotNullParameter(Ljava/lang/Object;Ljava/lang/String;)V

    const/16 v8, 0x20

    const/4 v9, 0x0

    const/4 v4, 0x0

    const/4 v5, 0x0

    const/4 v6, 0x0

    const/4 v7, 0x0

    move-object v1, p0

    move-object v2, p1

    move-object v3, p2

    .line 46
    invoke-direct/range {v1 .. v9}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;-><init>(Ljava/io/File;Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;Lkotlin/jvm/functions/Function1;Lkotlin/jvm/functions/Function1;Lkotlin/jvm/functions/Function2;IILkotlin/jvm/internal/DefaultConstructorMarker;)V

    return-void
.end method

.method private constructor <init>(Ljava/io/File;Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;Lkotlin/jvm/functions/Function1;Lkotlin/jvm/functions/Function1;Lkotlin/jvm/functions/Function2;I)V
    .locals 0

    .line 37
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 38
    iput-object p1, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->start:Ljava/io/File;

    .line 39
    iput-object p2, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->direction:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    .line 40
    iput-object p3, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->onEnter:Lkotlin/jvm/functions/Function1;

    .line 41
    iput-object p4, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->onLeave:Lkotlin/jvm/functions/Function1;

    .line 42
    iput-object p5, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->onFail:Lkotlin/jvm/functions/Function2;

    .line 43
    iput p6, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->maxDepth:I

    return-void
.end method

.method synthetic constructor <init>(Ljava/io/File;Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;Lkotlin/jvm/functions/Function1;Lkotlin/jvm/functions/Function1;Lkotlin/jvm/functions/Function2;IILkotlin/jvm/internal/DefaultConstructorMarker;)V
    .locals 7

    and-int/lit8 p8, p7, 0x2

    if-eqz p8, :cond_0

    .line 39
    sget-object p2, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;->TOP_DOWN:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    :cond_0
    move-object v2, p2

    and-int/lit8 p2, p7, 0x20

    if-eqz p2, :cond_1

    const p6, 0x7fffffff

    :cond_1
    move-object v0, p0

    move-object v1, p1

    move-object v3, p3

    move-object v4, p4

    move-object v5, p5

    move v6, p6

    .line 37
    invoke-direct/range {v0 .. v6}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;-><init>(Ljava/io/File;Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;Lkotlin/jvm/functions/Function1;Lkotlin/jvm/functions/Function1;Lkotlin/jvm/functions/Function2;I)V

    return-void
.end method

.method public static final synthetic access$getDirection$p(Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;)Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;
    .locals 0

    .line 37
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->direction:Lcom/scanflow/datacapture/barinternal/kotlin/io/FileWalkDirection;

    return-object p0
.end method

.method public static final synthetic access$getMaxDepth$p(Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;)I
    .locals 0

    .line 37
    iget p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->maxDepth:I

    return p0
.end method

.method public static final synthetic access$getOnEnter$p(Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;)Lkotlin/jvm/functions/Function1;
    .locals 0

    .line 37
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->onEnter:Lkotlin/jvm/functions/Function1;

    return-object p0
.end method

.method public static final synthetic access$getOnFail$p(Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;)Lkotlin/jvm/functions/Function2;
    .locals 0

    .line 37
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->onFail:Lkotlin/jvm/functions/Function2;

    return-object p0
.end method

.method public static final synthetic access$getOnLeave$p(Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;)Lkotlin/jvm/functions/Function1;
    .locals 0

    .line 37
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->onLeave:Lkotlin/jvm/functions/Function1;

    return-object p0
.end method

.method public static final synthetic access$getStart$p(Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;)Ljava/io/File;
    .locals 0

    .line 37
    iget-object p0, p0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;->start:Ljava/io/File;

    return-object p0
.end method


# virtual methods
.method public iterator()Ljava/util/Iterator;
    .locals 1

    .line 50
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator;

    invoke-direct {v0, p0}, Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk$FileTreeWalkIterator;-><init>(Lcom/scanflow/datacapture/barinternal/kotlin/io/FileTreeWalk;)V

    return-object v0
.end method
