.class public Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;
.super Ljava/lang/Object;
.source "DogLinkedList.java"


# annotations
.annotation system Ldalvik/annotation/EnclosingClass;
    value = Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList;
.end annotation

.annotation system Ldalvik/annotation/InnerClass;
    accessFlags = 0x9
    name = "Element"
.end annotation


# instance fields
.field public next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

.field public object:Ljava/lang/Object;

.field public prev:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;


# direct methods
.method public constructor <init>()V
    .locals 0

    .line 456
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    return-void
.end method


# virtual methods
.method public clear()V
    .locals 1

    const/4 v0, 0x0

    .line 463
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->next:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 464
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->prev:Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;

    .line 465
    iput-object v0, p0, Lcom/scanflow/datacapture/barinternal/org/ddogleg/struct/DogLinkedList$Element;->object:Ljava/lang/Object;

    return-void
.end method
