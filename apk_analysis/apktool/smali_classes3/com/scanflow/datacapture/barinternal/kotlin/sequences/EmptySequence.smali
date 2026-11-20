.class final Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;
.super Ljava/lang/Object;
.source "Sequences.kt"

# interfaces
.implements Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
.implements Lcom/scanflow/datacapture/barinternal/kotlin/sequences/DropTakeSequence;


# static fields
.field public static final INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .line 0
    new-instance v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;

    invoke-direct {v0}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;-><init>()V

    sput-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;

    return-void
.end method

.method private constructor <init>()V
    .locals 0

    .line 77
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public drop(I)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;
    .locals 0

    .line 79
    sget-object p1, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;

    return-object p1
.end method

.method public bridge synthetic drop(I)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/Sequence;
    .locals 0

    .line 77
    invoke-virtual {p0, p1}, Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;->drop(I)Lcom/scanflow/datacapture/barinternal/kotlin/sequences/EmptySequence;

    move-result-object p1

    return-object p1
.end method

.method public iterator()Ljava/util/Iterator;
    .locals 1

    .line 78
    sget-object v0, Lcom/scanflow/datacapture/barinternal/kotlin/collections/EmptyIterator;->INSTANCE:Lcom/scanflow/datacapture/barinternal/kotlin/collections/EmptyIterator;

    return-object v0
.end method
