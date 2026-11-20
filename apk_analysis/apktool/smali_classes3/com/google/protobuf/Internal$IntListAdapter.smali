.class public Lcom/google/protobuf/Internal$IntListAdapter;
.super Ljava/util/AbstractList;
.source "Internal.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/google/protobuf/Internal;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "IntListAdapter"
.end annotation

.annotation system Ldalvik/annotation/MemberClasses;
    value = {
        Lcom/google/protobuf/Internal$IntListAdapter$IntConverter;
    }
.end annotation

.annotation system Ldalvik/annotation/Signature;
    value = {
        "<T:",
        "Ljava/lang/Object;",
        ">",
        "Ljava/util/AbstractList<",
        "TT;>;"
    }
.end annotation


# instance fields
.field private final converter:Lcom/google/protobuf/Internal$IntListAdapter$IntConverter;
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "Lcom/google/protobuf/Internal$IntListAdapter$IntConverter<",
            "TT;>;"
        }
    .end annotation
.end field

.field private final fromList:Lcom/google/protobuf/Internal$IntList;


# direct methods
.method public constructor <init>(Lcom/google/protobuf/Internal$IntList;Lcom/google/protobuf/Internal$IntListAdapter$IntConverter;)V
    .locals 0
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(",
            "Lcom/google/protobuf/Internal$IntList;",
            "Lcom/google/protobuf/Internal$IntListAdapter$IntConverter<",
            "TT;>;)V"
        }
    .end annotation

    .line 387
    invoke-direct {p0}, Ljava/util/AbstractList;-><init>()V

    .line 388
    iput-object p1, p0, Lcom/google/protobuf/Internal$IntListAdapter;->fromList:Lcom/google/protobuf/Internal$IntList;

    .line 389
    iput-object p2, p0, Lcom/google/protobuf/Internal$IntListAdapter;->converter:Lcom/google/protobuf/Internal$IntListAdapter$IntConverter;

    return-void
.end method


# virtual methods
.method public get(I)Ljava/lang/Object;
    .locals 2
    .annotation system Ldalvik/annotation/Signature;
        value = {
            "(I)TT;"
        }
    .end annotation

    .line 394
    iget-object v0, p0, Lcom/google/protobuf/Internal$IntListAdapter;->converter:Lcom/google/protobuf/Internal$IntListAdapter$IntConverter;

    iget-object v1, p0, Lcom/google/protobuf/Internal$IntListAdapter;->fromList:Lcom/google/protobuf/Internal$IntList;

    invoke-interface {v1, p1}, Lcom/google/protobuf/Internal$IntList;->getInt(I)I

    move-result p1

    invoke-interface {v0, p1}, Lcom/google/protobuf/Internal$IntListAdapter$IntConverter;->convert(I)Ljava/lang/Object;

    move-result-object p1

    return-object p1
.end method

.method public size()I
    .locals 1

    .line 399
    iget-object v0, p0, Lcom/google/protobuf/Internal$IntListAdapter;->fromList:Lcom/google/protobuf/Internal$IntList;

    invoke-interface {v0}, Ljava/util/List;->size()I

    move-result v0

    return v0
.end method
